using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class lloker : MonoBehaviour
{
    public List<Transform> targets;
    public Transform activetarget;
    public int targetnum = 0;
    public tan tan;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activetarget = targets[targetnum];

        Vector3 facingdirection = transform.forward;
        float facingdegrees = tan.vectortoangle(facingdirection);
        Debug.Log(facingdegrees);
    }

    // Update is called once per frame
    void Update()
    {
        float rot = tan.vectortoangle(activetarget.position);
        float rot1 = tan.vectortoangle(targets[0].position);

        if (!Keyboard.current.shiftKey.isPressed)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rot);
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rot1);

        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            targetnum++;
            if(targetnum >= targets.Count)
            {
                targetnum = 0;
            }
            activetarget = targets[targetnum];
        }
    }


}
