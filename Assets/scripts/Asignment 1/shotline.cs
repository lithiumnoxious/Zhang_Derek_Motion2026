using UnityEngine;

public class shotline : MonoBehaviour
{
    //public Transform targettransform;
    public bool leftRight;
    public static float rotationSpeed;
    public float rotationSpeedMultiplier;
    public int baseSpeed;

    public static bool inZone1; bool inZ1Boost;

    public static bool inZone2; bool inZ2Boost;


    public float inView;
    public bool isInView;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationSpeed = 1;
    }

    // Update is called once per frame
    public float rotDifference;
    void Update()
    {
        checkInZone();

        Vector3 directiontotarget = Player.playerPos.position - transform.position;
        rotDifference = Vector3.Dot(directiontotarget.normalized, -transform.right);
        if ((rotDifference < inView && rotDifference > -inView)&& (inZone1||inZone2))
        {
            Debug.DrawLine(transform.position, transform.up * (Radar.radiusZone2), Color.darkRed);
            isInView = true;
        }
        else
        {
            Debug.DrawLine(transform.position, transform.up * Radar.radiusZone2, Color.yellow);
            isInView = false;
        }

        if (inZone1 || inZone2)
        {
            if (rotDifference > 0)
            {
                leftRight = true;
            }
            else
            {
                leftRight = false;
            }
        }
            if (leftRight)
            {
                turn(1);
            }
            else
            {
                turn(-1);
            }
    }
    public void checkInZone()
    {
        if (!inZ1Boost && inZone1)
        {
            rotationSpeed += rotationSpeedMultiplier * portallspawner.difficulty;
            inZ1Boost = true;
        }
        if (!inZ2Boost && inZone2)
        {
            rotationSpeed += rotationSpeedMultiplier * portallspawner.difficulty;
            inZ2Boost = true;
        }
        if (inZ1Boost && !inZone1)
        {
            rotationSpeed -= rotationSpeedMultiplier * portallspawner.difficulty;
            inZ1Boost = false;
        }
        if (inZ2Boost && !inZone2)
        {
            rotationSpeed -= rotationSpeedMultiplier * portallspawner.difficulty;
            inZ2Boost = false;
        }
    }

    public void turn(int direction)
    {
        transform.eulerAngles += Vector3.forward * Time.deltaTime * baseSpeed * rotationSpeed * direction * portallspawner.difficulty;
    }



}
