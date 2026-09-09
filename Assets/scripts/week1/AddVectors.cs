using UnityEngine;
using UnityEngine.InputSystem;

public class AddVectors : MonoBehaviour
{
    public Transform rtransform;
    public Transform btransform;
    public Vector2 rPlusB;
    public Vector2 origin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rPlusB = rtransform.position + btransform.position;
        if (Keyboard.current.bKey.isPressed)
        {
            Debug.DrawLine(origin, btransform.position, Color.blue);
        }
        if (Keyboard.current.rKey.isPressed)
        {
            Debug.DrawLine(origin, rtransform.position, Color.red);
        }
        if (Keyboard.current.bKey.isPressed && Keyboard.current.rKey.isPressed)
        {
            Debug.DrawLine(origin, rPlusB, Color.magenta);
        }
    }
}
