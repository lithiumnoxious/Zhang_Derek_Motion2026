using NUnit.Framework;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    public Vector2 intitalpress;
    public Vector2 mousepos;
    public float t;
    public List<Vector2> Listp;
    public float totallength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            intitalpress = mousepos;
            Listp.Add(intitalpress);
             t = 0;
        }
        if (Mouse.current.leftButton.isPressed)
        {
            t+= 0.1f * Time.deltaTime;
            if(t >= 0.1)
            {
                Debug.DrawLine(intitalpress,mousepos, Color.white, 10);
                intitalpress = mousepos;
                Listp.Add(intitalpress);
                t = 0;
            }
        }
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            for (int i = 0; i < Listp.Count - 1; i++)
            {
                Vector2 current = Listp[i];
                Vector2 next = Listp[i + 1];
                float CNX = current.x* current.x + next.x*next.x;
                float CNY = current.y * current.y + next.y * next.y;
                totallength += Mathf.Sqrt(CNX + CNY);
            }
            Debug.Log(totallength);
            totallength = 0;
            Listp.Clear();
        }
    }
}
