using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class angelTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public List<float> angles;
    int index = 0;
    public Vector3 startPoint;
    public float tempX;
    public float tempY;

    public float radius;
    public Vector3 circleOffset;
    public float timel;
    public float angleBase = 10;
    public float angledifference = 10;
    public bool circleOn;


    void Start()
    {
        float fortyFiveDegree = 45f;

        float ffDInRadians = fortyFiveDegree * Mathf.Deg2Rad;


        float twoPiRadians = 2 * Mathf.PI;
        float tprInDegrees = twoPiRadians * Mathf.Rad2Deg;

        float currentangle = 90f;
        Mathf.Sin(currentangle * Mathf.PI); // use radian
        Mathf.Tan(currentangle * Mathf.PI); // use radian

        for (int i = 0; i < 36; i++)
        {
            angles.Add(angleBase);
            angleBase += angledifference;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            circleOn = true;
        }

        if ( timel >= 1 && circleOn)
        {
            Debug.Log (angles[index]);
            tempX = mathCos(angles[index]);
            tempY = mathSin(angles[index] + 1);

            //Vector2 tempP = new Vector2(tempX, tempY) * 2;

            Vector3 CirclePoint = new Vector3(tempX, tempY)*radius + circleOffset;
            Vector3 startPoint = Vector3.zero + circleOffset;
            Debug.DrawLine(startPoint, CirclePoint, Color.yellow, 5);


            index++;
            timel = 0;
            if(index >= angles.Count)
            {
                circleOn = false;
                index = 0;
            }
        }
        timel += 10 * Time.deltaTime;
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
    public float mathTan(float angle)
    {
        float ra = Mathf.Tan(angle * Mathf.Deg2Rad); // only use radian
        return (ra);
    }

}
