using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public Vector3 currentvelo;
    public int speed;
    public float rotspeed;
    void Update()
    {
        EnemyMovement();

    }

    public void EnemyMovement() //w3 task 1
    {
        Vector3 acceldirection = Vector3.zero;
        if (Keyboard.current.aKey.isPressed)
        {
            //acceldirection += Vector3.left;
            transform.Rotate(0,0,-rotspeed * Time.deltaTime);

        }
        if (Keyboard.current.dKey.isPressed)
        {
            //acceldirection += Vector3.right;
            transform.Rotate(0, 0, rotspeed * Time.deltaTime);

        }
        if (Keyboard.current.wKey.isPressed)
        {
            acceldirection += gameObject.transform.up;

        }
        if (Keyboard.current.sKey.isPressed)
        {
            acceldirection += -gameObject.transform.up;

        }
        currentvelo += acceldirection.normalized * Time.deltaTime;
        transform.position += currentvelo * speed * Time.deltaTime;
    }
    }
