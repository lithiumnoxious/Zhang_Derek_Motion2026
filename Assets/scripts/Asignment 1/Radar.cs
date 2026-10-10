using UnityEngine;

public class Radar : MonoBehaviour
{

    public int circlesides;
    public int sidesPlus;
    public bool sidesMinus;
    public float circleradius;
    public float time = 0;
    public float CurveTime = 0;
    public AnimationCurve curve;
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
        radius += curve.Evaluate(CurveTime);



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
            if (enemydist - 0.5 < radius)
            {
                Debug.DrawLine(startP, EndP, Color.red * col);
            }
            else
            {
                Debug.DrawLine(startP, EndP, Color.darkSeaGreen * col);
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
