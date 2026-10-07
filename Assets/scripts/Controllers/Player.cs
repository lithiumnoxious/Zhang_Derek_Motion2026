using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
     public static Transform playerPos;
    //public Transform enemyTransform;
    public GameObject bombPrefab;
    //public Transform bombsTransform;
    public Vector3 inOffset;
    public int bombtrailspacing;

    public int numberOfTrailBombs;
    public float angle;

    public Vector3 currentvelo = Vector3.right;
    public float speed;
    public float maxspeed;
    //public float acceltime;
    //public float currentaccel;
    //public float decceltime;
    //public float deccel;
    public bool booster;
    public float timer = 0;
    public float shipdeccel;


    public int circlesides;
    public float circleradius;
    //public GameObject enemy;


    public float powerRadius;
    public int powerNum;
    public GameObject pPower;

    private void Start()
    {
        playerPos = transform;

        //transform.position = transform.position + currentvelo;
        //transform.position += Vector3.right;
        //currentaccel = maxspeed / acceltime;
        //deccel = maxspeed / decceltime;
    }

    void Update()
    {
        playerPos = transform;
        //transform.position = transform.position + currentvelo;



        if (Keyboard.current.bKey.wasReleasedThisFrame)
        {
            //when b key is pressed the bomb will be instantiated
            SpawnBombAtOffset(inOffset);//w2 task 1
        }
        if (Keyboard.current.tKey.wasReleasedThisFrame)
        {
            SpawnBombTrail(bombtrailspacing, numberOfTrailBombs);
        }
        if (Keyboard.current.rKey.wasReleasedThisFrame)
        {
            //SpawneBombOnRandomCorner(Random.Range(0, 1));//w2 task 2
        }


        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            WarpPlayer(Enemy.enemyPos, 0.5f); //w2 task 3
        }

        angle = transform.eulerAngles.z;


        if (Keyboard.current.wKey.wasReleasedThisFrame)
        {
            warpDrive(transform.position, 2);
            DetectAteroids(5, asteroidTransforms); //w2 task 4
        }

        //if (Keyboard.current.leftArrowKey.isPressed)
        //{
        //    //PlayerMovement3(-1,0,0);
        //    PlayerMovement2(Vector3.left);
        //}
        //if (Keyboard.current.rightArrowKey.isPressed)
        //{
        //    //PlayerMovement3(1, 0, 0);
        //    PlayerMovement2(Vector3.right);

        //}
        //if (Keyboard.current.upArrowKey.isPressed)
        //{
        //    //PlayerMovement3(0, 1, 0);
        //    PlayerMovement2(Vector3.up);

        //}
        //if (Keyboard.current.downArrowKey.isPressed)
        //{
        //    //PlayerMovement(0, -1, 0);
        //    PlayerMovement2(Vector3.down);

        //}
        PlayerMovement(); //w3 task 1
        //if (Keyboard.current.leftArrowKey.isPressed|| Keyboard.current.rightArrowKey.isPressed|| Keyboard.current.upArrowKey.isPressed|| Keyboard.current.downArrowKey.isPressed)
        //{
        //    playermovement();
        //}

        EnemyRadar(circleradius,circlesides);
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            EnemyRadar(circleradius,circlesides);
        }


        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            SpawnPowerups(powerRadius, powerNum);
        }

    }
    public void spawnbomboffset(Vector3 inoffset)
    {

        //Instantiated the bomb prefab, using the inoffset vector3 and keeping the rotation of the inoffset
        GameObject bob = Instantiate(bombPrefab, inoffset, Quaternion.identity);
        //miss understood the bounus challenge
        StartCoroutine(die(bob));
    }
    public void SpawnBombAtOffset(Vector3 inoffset) //Task 1
    {
        GameObject bob = Instantiate(bombPrefab, transform.position + inoffset, Quaternion.identity);
        Destroy(bob, 5);
    }
    public void SpawnBombTrail(float BombSpacing, int NumberOfBombs)//task 1
    {

        for (int i = 0; i < NumberOfBombs; i++)
        {
            GameObject bob = Instantiate(bombPrefab, new Vector2(transform.position.x, transform.position.y - bombtrailspacing * (i + 1)), transform.rotation * Quaternion.Euler(0, 0, angle));

        }
    }

    //public void SpawneBombOnRandomCorner(float inDistance)//task 2
    //{
    //    int r = Random.Range(0, 4);
    //    switch (r)
    //    {
    //        case 0:
    //            GameObject tl = Instantiate(bombPrefab, transform.position + Vector3.up + Vector3.left + new Vector3(-inDistance, inDistance, 0).normalized, Quaternion.identity);
    //            break;
    //        case 1:
    //            GameObject tr = Instantiate(bombPrefab, transform.position + Vector3.up + Vector3.right + new Vector3(inDistance, inDistance, 0).normalized, Quaternion.identity);
    //            break;
    //        case 2:
    //            GameObject bl = Instantiate(bombPrefab, transform.position + Vector3.down + Vector3.left + new Vector3(-inDistance, -inDistance, 0).normalized, Quaternion.identity);
    //            break;
    //        case 3:
    //            GameObject br = Instantiate(bombPrefab, transform.position + Vector3.down + Vector3.right + new Vector3(inDistance, -inDistance, 0).normalized, Quaternion.identity);
    //            break;
    //    }


    //}
    public IEnumerator die(GameObject bob)
    {
        //bomb is delayed for 3 seconds but still destroyed
        Destroy(bob, 3);
        //says bomba so I know it works
        Debug.Log("bomba");
        yield return (null);
    }
    public void warpDrive(Vector3 ship, float speed)
    {
        //vector3 of ship instead of transform.pos is here because trans.pos can not to adjusted like how i am using it for
        ship.y += speed;
        //match the new ship vector with the actual gameobj pos
        transform.position = ship;
    }
    public void WarpPlayer(Transform target, float ratio) //task 3
    {
        if (ratio > 1)
        {
            ratio = 1;
        }
        if (ratio < 0)
        {
            ratio = 0;
        }
        transform.position = Vector3.Lerp(transform.position, target.position, ratio);
    }

    public void DetectAteroids(float inMaxRange, List<Transform> inAsteroids)//task 4
    {
        foreach (Transform A in inAsteroids)
        {
            float distance = Vector3.Distance(transform.position, A.position);
            if (distance < inMaxRange)
            {
                Debug.DrawLine(transform.position, A.position, Color.yellow, 10);
            }
        }
    }
    public void PlayerMovement3(int x, int y, int z)
    {
        transform.position += new Vector3(x, y, z);
    }
    public void PlayerMovement2(Vector3 v)
    {
        transform.position += v.normalized * speed * Time.deltaTime;
    }
    public void PlayerMovement() //w3 task 1
    {
        Vector3 acceldirection = Vector3.zero;
        //currentvelo = Vector3.zero;
        if (Keyboard.current.leftArrowKey.isPressed) //w3 task 1a
        {
            acceldirection += Vector3.left;
            booster = true;
            timer = 0;
        }
        if (Keyboard.current.rightArrowKey.isPressed)//w3 task 1a
        {
            acceldirection += Vector3.right;
            booster = true;
            timer = 0;
        }
        if (Keyboard.current.upArrowKey.isPressed)//w3 task 1a
        {
            acceldirection += Vector3.up;
            booster = true;
            timer = 0;
        }
        if (Keyboard.current.downArrowKey.isPressed)//w3 task 1a
        {
            acceldirection += Vector3.down;
            booster = true;
            timer = 0;
        }
        currentvelo += acceldirection.normalized * Time.deltaTime;//w3 task 1b
        transform.position += currentvelo * speed * Time.deltaTime;

        if (currentvelo.magnitude > maxspeed)
        {
            currentvelo = currentvelo.normalized * maxspeed;
        }
        if (booster) //w3 task 1c
        {
            if (timer >= 1)
            {
                booster = false;
            }
            else
            {
                timer += shipdeccel * Time.deltaTime;
            }
        }
        if (!booster)
        {
            currentvelo -= currentvelo.normalized * Time.deltaTime;
        }




        //normalized is used to keep the continous movement stable
        //time.deltatime is used instead of frame rate also for stability sake
        ////furthermore time.deltatime is used when real life seconds matter ie gravity and projectiles
    }

    
    public float enemydist;

    public void EnemyRadar(float radius, int points)
    {
        float Firstdiv = 360f / points;
        float Si;
        float oldSi;
        float tempX;
        float tempY;
        float tempX2 = 0;
        float tempY2 = 0;

        for (float i = 0; i < points+1; i++)
        {
            Si = Firstdiv * (i);
            oldSi = Si;
            //Debug.Log(Si); testing if the sides added up to 360

            tempX = mathCos(Si);
            tempY = mathSin(oldSi);

            if (i == 0)
            {
                tempX2 = tempX;
                tempY2 = tempY;
            }
            
            Vector3 startP = new Vector3(tempX, tempY) * radius + transform.position;
            Vector3 EndP = new Vector3(tempX2, tempY2) * radius + transform.position;

            tempX2 = tempX;
            tempY2 = tempY;


            enemydist = Vector2.Distance(transform.position, Enemy.enemyPos.position);
            if (enemydist-0.5 < radius )
            {
                Debug.DrawLine(startP, EndP, Color.red);
            }
            else
            {
                Debug.DrawLine(startP, EndP, Color.darkSeaGreen);
            }
        }
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float Firstdiv = 360f / numberOfPowerups;
        float powerpos;

        for (float i = 0; i < numberOfPowerups + 1; i++)
        {
            powerpos = Firstdiv * (i);
            Debug.Log(powerpos); //testing if the sides added up to 360

            float tempX = mathCos(powerpos);
            float tempY = mathSin(powerpos);

            Vector3 powerP = new Vector3(tempX, tempY) * radius + transform.position;

            GameObject powerup = Instantiate(pPower, powerP, Quaternion.identity);
            Destroy(powerup,5 );
        }
    }


    public float mathCos(float angle)
    {
        float ra = Mathf.Cos(angle * Mathf.Deg2Rad); // only use radian
        return (ra);
    }
    public float mathSin(float angle)
    {
        float ra = Mathf.Sin(angle * Mathf.Deg2Rad); // only use radian
        return (ra);
    }
}
