using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
     public static Transform enemyPos;
    public Vector3 currentvelo;
    public int speed;
    public float rotspeed;

    private void Start()
    {
        enemyPos = transform;

    }
    void Update()
    {
        enemyPos = transform;
        EnemyMovement();

    }

    public void EnemyMovement()
    {
        Vector3 acceldirection = Vector3.zero;
        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(0,0,-rotspeed * Time.deltaTime);
        }
        if (Keyboard.current.dKey.isPressed)
        {
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
