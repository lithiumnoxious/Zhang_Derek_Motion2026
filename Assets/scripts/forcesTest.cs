using UnityEngine;
using UnityEngine.InputSystem;

public class forcesTest : MonoBehaviour
{
    public float forceStrength;
    public Rigidbody2D rbDD ;

    public enum projectType
    {
        arrow,cannonball, coin
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbDD = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 MousePos = Mouse.current.position.ReadValue();
            Vector3 WorldMP = Camera.main.ScreenToWorldPoint(MousePos);
            WorldMP.z = 0;
            
            Vector3 forceDirection= WorldMP - transform.position;



            rbDD.AddForce(forceDirection.normalized * forceStrength,ForceMode2D.Force);
        }
    }
}
