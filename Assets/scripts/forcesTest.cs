using UnityEngine;
using UnityEngine.InputSystem;

public class forcesTest : MonoBehaviour
{
    public float forceStrength;
    public Rigidbody2D rbDD;
    public BoxCollider2D boxCollider;
    public bool posXLock = false; public bool posZLock = false; public bool posAllLock = false;
    //public enum RigidbodyConstraints2D
    //{
    //    FreezePositionX, FreezePosY, FreezePosR
    //}

    public enum projectType
    {
        arrow, cannonball, coin
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbDD = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        Vector3 WorldMP = Camera.main.ScreenToWorldPoint(MousePos);
        WorldMP.z = 0;
        Vector3 forceDirection = WorldMP - transform.position;
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rbDD.AddForce(forceDirection.normalized * forceStrength, ForceMode2D.Force);
        }
        if (Keyboard.current.eKey.wasPressedThisFrame) //Week 9 part 3
        {
            rbDD.AddForceAtPosition(forceDirection.normalized * forceStrength, forceDirection.normalized * forceStrength, ForceMode2D.Force);
        }

        //OnCollisionEnter2D(boxCollider);

        //Week 9 part 1
        if (Keyboard.current.xKey.wasReleasedThisFrame) //easy to turn on and off
        {
            if (posXLock) //resets the contraints
            {
                rbDD.constraints = RigidbodyConstraints2D.None;
            }
            if (!posXLock) //contrains the pos of gameobject to only move on y and z
            {
                rbDD.constraints = RigidbodyConstraints2D.FreezePositionX;
            }
            posXLock = !posXLock;

        }
        //Week 9 part 1
        if (Keyboard.current.zKey.wasReleasedThisFrame)
        {
            if (posZLock)
            {
                rbDD.constraints = RigidbodyConstraints2D.None;
            }
            if (!posZLock) //contrains the pos of gameobject to only move on x and y
            {
                rbDD.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            posZLock = !posZLock;
        }
        //Week 9 part 1
        if (Keyboard.current.aKey.wasReleasedThisFrame)
        {
            if (posAllLock)
            {
                rbDD.constraints = RigidbodyConstraints2D.None;
            }
            if (!posAllLock) //stops the gameobject from moving, also stops all further movement
            {
                rbDD.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            posAllLock = !posAllLock;


        }
        //Week 9 part 2
        if (Keyboard.current.digit1Key.wasReleasedThisFrame)
        {
            rbDD.bodyType = RigidbodyType2D.Dynamic;   // Affected by gravity and forces
        }
        //Week 9 part 2
        if (Keyboard.current.digit2Key.wasReleasedThisFrame)
        {
            rbDD.bodyType = RigidbodyType2D.Kinematic; // Moves only in script, also ignores forces/gravity
        }
        //Week 9 part 2
        if (Keyboard.current.digit3Key.wasReleasedThisFrame)
        {
            rbDD.bodyType = RigidbodyType2D.Static;    // Completely immovable; 
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision enter");
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision exit");
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision stay");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger enter");

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger exit");

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger stay");

    }
}
