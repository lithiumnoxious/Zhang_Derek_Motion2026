using UnityEngine;
using UnityEngine.InputSystem;

public class forcesTest : MonoBehaviour
{
    public float forceStrength;
    public Rigidbody2D rbDD;
    public BoxCollider2D boxCollider;

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
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 MousePos = Mouse.current.position.ReadValue();
            Vector3 WorldMP = Camera.main.ScreenToWorldPoint(MousePos);
            WorldMP.z = 0;

            Vector3 forceDirection = WorldMP - transform.position;



            rbDD.AddForce(forceDirection.normalized * forceStrength, ForceMode2D.Force);
        }
        //OnCollisionEnter2D(boxCollider);

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
