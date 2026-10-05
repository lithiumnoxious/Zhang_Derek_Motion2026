using NUnit.Framework.Internal;
using UnityEngine;

public class anglecomparison : MonoBehaviour
{
    public tan tan;
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
        

    }
}
