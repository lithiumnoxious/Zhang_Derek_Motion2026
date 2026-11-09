using UnityEngine;

public class Radar : MonoBehaviour
{
    public static float SpawnRange;
    public static float radiusZone1; public static float radiusZone2;
    public float circleRadius1; public float circleRadius2;
    public int circlesides; public int sidesPlus; public bool sidesMinus;
    public float time; public float CurveTime; public AnimationCurve curve; public bool curveOn;

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
        if (SpawnRange != (radiusZone1 + radiusZone2) / 2)
        {
            SpawnRange = (radiusZone1 + radiusZone2) / 2;
        }

        rRadar(circleRadius1, circlesides + sidesPlus, 1);
        rRadar(circleRadius1 + circleRadius2, circlesides + sidesPlus, 0.7f);
    }

    public float enemydist;
    public float playerdist;
    public void rRadar(float radius, int points, float col)
    {
        float Firstdiv = 360f / points;
        float Si;
        float tempX; float tempX2 = 0;
        float tempY; float tempY2 = 0;

        CurveTime += Time.deltaTime;
        if (CurveTime > 1)
        {
            CurveTime = 0;
        }
        if (curveOn)
        {
            radius *= curve.Evaluate(CurveTime);
            radiusZone1 = (circleRadius1) * curve.Evaluate(CurveTime);
            radiusZone2 = (circleRadius1 + circleRadius2) * curve.Evaluate(CurveTime);
        }
        else
        {
            radiusZone1 = circleRadius1;
            radiusZone2 = circleRadius1 + circleRadius2;
        }

        for (float i = 0; i < points + 1; i++)
        {
            Si = Firstdiv * (i);
            tempX = Player.mathCos(Si);
            tempY = Player.mathSin(Si);

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
}
