using UnityEngine;

public class shotline : MonoBehaviour
{
    //public Transform targettransform;
    public bool left;
    public static float rotationSpeed;
    public float rotationSpeedMultiplier;
    public static bool inZone1;
    public bool inZ1Boost;
    public static bool inZone2;
    public bool inZ2Boost;

    public float inView;
    public bool isInView;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        checkInZone();

        Vector3 directiontotarget = Player.playerPos.position - transform.position;// 
        //Debug.DrawLine(transform.position, directiontotarget - transform.position, Color.pink);

        float rotDifference = VectorDot(directiontotarget, -transform.right);
        if (rotDifference < inView && rotDifference > -inView)
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
                left = true;
            }
            else
            {
                left = false;
            }
        }

        if (left)
        {
            turn(1);
        }
        else
        {
            turn(-1);
        }
    }
    public static float VectorDot(Vector3 v1, Vector3 v2)
    {
        float dotProduct = v1.x * v2.x + v1.y * v2.y;
        return dotProduct;
    }
    public void checkInZone()
    {
        if (!inZ1Boost && inZone1)
        {
            rotationSpeed += rotationSpeedMultiplier;
            inZ1Boost = true;
        }
        if (!inZ2Boost && inZone2)
        {
            rotationSpeed += rotationSpeedMultiplier;
            inZ2Boost = true;
        }
        if (inZ1Boost && !inZone1)
        {
            rotationSpeed -= rotationSpeedMultiplier;
            inZ1Boost = false;
        }
        if (inZ2Boost && !inZone2)
        {
            rotationSpeed -= rotationSpeedMultiplier;
            inZ2Boost = false;
        }
    }

    public void turn(int direction)
    {
        transform.eulerAngles += Vector3.forward * Time.deltaTime * 30 * rotationSpeed * direction;
    }

    

}
