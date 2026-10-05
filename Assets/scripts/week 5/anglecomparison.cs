using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class anglecomparison : MonoBehaviour
{
    public tan tan;
    public List<Transform> targets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 facingdirection = transform.forward;
        float facingdegrees = tan.vectortoangle(facingdirection);
        Debug.Log(facingdegrees);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 first = targets[0].position;
        //Vector3 firstTarget = targets[targetIndex].position;

        //Vector3 vectorToFirstTarget = firstTarget - transform.position;

        //float angleToFirstTarget = TestAngles.VectorToAngle(vectorToFirstTarget);

        ////We have to set the whole vector for eulerAngles
        //transform.eulerAngles = new Vector3(0f, 0f, angleToFirstTarget);

        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //    targetIndex++;
        //    if (targetIndex >= targets.Count)
        //    {
        //        targetIndex = 0;
        //    }
        //}

    }


    
}
