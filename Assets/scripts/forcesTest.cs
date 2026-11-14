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
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Vector3 MousePos = Mouse.current.position.ReadValue();
            Vector3 WorldMP = Camera.main.ScreenToWorldPoint(MousePos);
            WorldMP.z = 0;

            Vector3 forceDirection = WorldMP - transform.position;
            rbDD.AddForce(forceDirection.normalized * forceStrength, ForceMode2D.Force);
        }
        //OnCollisionEnter2D(boxCollider);

        if (Keyboard.current.xKey.wasReleasedThisFrame)
        {
            if (posXLock)
            {
                rbDD.constraints = RigidbodyConstraints2D.None;
            }
            if (!posXLock)
            {
                rbDD.constraints = RigidbodyConstraints2D.FreezePositionX;
            }
            posXLock = !posXLock;
            
        }
        if (Keyboard.current.zKey.wasReleasedThisFrame)
        {
            if (posZLock)
            {
                rbDD.constraints = RigidbodyConstraints2D.None;
            }
            if (!posZLock)
            {
                rbDD.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            posZLock = !posZLock;
        }
        if (Keyboard.current.aKey.wasReleasedThisFrame)
        {
            if (posAllLock)
            {
                rbDD.constraints = RigidbodyConstraints2D.None;
            }
            if (!posAllLock)
            {
                rbDD.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            posAllLock = !posAllLock;


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
