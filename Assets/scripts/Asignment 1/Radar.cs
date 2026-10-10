using UnityEngine;

public class Radar : MonoBehaviour
{
    public float circleradius;
    public int circlesides;
    public int sidesPlus;
    public bool sidesMinus;
    public float time;
    public float CurveTime;
    public AnimationCurve curve;
    public bool curveOn;

    public static float radiusZone1;
    public static float radiusZone2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sidesPlus = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            SideChanger();
            time = 0;
        }

        EnemyRadar(circleradius, circlesides + sidesPlus, 1);
        EnemyRadar(circleradius + circlesides / 2, circlesides + sidesPlus, 0.7f);


    }

    public float enemydist;
    public float playerdist;

    public void EnemyRadar(float radius, int points, float col)
    {
        float Firstdiv = 360f / points;
        float Si;
        //float oldSi;
        float tempX;
        float tempY;
        float tempX2 = 0;
        float tempY2 = 0;

        CurveTime += Time.deltaTime;
        if (CurveTime > 1)
        {
            CurveTime = 0;
        }
        if (curveOn)
        {
            radius += curve.Evaluate(CurveTime);
            radiusZone1 = circleradius + curve.Evaluate(CurveTime);
            radiusZone2 = (circleradius + circlesides / 2) + curve.Evaluate(CurveTime);
        }
        else
        {
            radiusZone1 = circleradius;
            radiusZone2 = (circleradius + circlesides / 2);
        }
        //radiusNum = radius;

        for (float i = 0; i < points + 1; i++)
        {
            Si = Firstdiv * (i);
            tempX = mathCos(Si);
            tempY = mathSin(Si);

            if (i == 0)
            {
                tempX2 = tempX;
                tempY2 = tempY;
            }

            Vector3 startP = new Vector3(tempX, tempY) * radius + transform.position;
            Vector3 EndP = new Vector3(tempX2, tempY2) * radius + transform.position;

            tempX2 = tempX;
            tempY2 = tempY;

            enemydist = Vector2.Distance(transform.position, Enemy.enemyPos.position);
            playerdist = Vector2.Distance(transform.position, Player.playerPos.position);

            if (enemydist - 0.5 < radius || playerdist - 0.5 < radius)
            {
                Debug.DrawLine(startP, EndP, Color.red * col);
                //shotline.inZone1 = true;
                if (enemydist < radiusZone1 || playerdist < radiusZone1)
                {
                    shotline.inZone1 = true;
                }
                if (enemydist < radiusZone2 || playerdist < radiusZone2)
                {
                    shotline.inZone2 = true;
                }

            }
            else
            {
                Debug.DrawLine(startP, EndP, Color.darkSeaGreen * col);
                shotline.inZone1 = false;
                shotline.inZone2 = false;

            }
        }
    }
    public void SideChanger()
    {
        if (!sidesMinus)
        {
            sidesPlus++;
            if (sidesPlus >= 10)
            {
                sidesMinus = true;
            }
        }
        else
        {
            sidesPlus--;
            if (sidesPlus <= 0)
            {
                sidesMinus = false;
            }
        }
    }



    public float mathCos(float angle)
    {
        float ra = Mathf.Cos(angle * Mathf.Deg2Rad); // only use radian
        return (ra);
    }
    public float mathSin(float angle)
    {
        float ra = Mathf.Sin(angle * Mathf.Deg2Rad); // only use radian
        return (ra);
    }
}
