using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector3 inOffset;
    public int bombtrailspacing;

    public int numberOfTrailBombs;
    public float angle;


    void Update()
    {
        if (Keyboard.current.bKey.wasReleasedThisFrame)
        {
            //when b key is pressed the bomb will be instantiated
            SpawnBombAtOffset(inOffset);//task 1
        }
        if (Keyboard.current.tKey.wasReleasedThisFrame)
        {
            SpawnBombTrail(bombtrailspacing, numberOfTrailBombs);
        }
        if (Keyboard.current.rKey.wasReleasedThisFrame)
        {
            SpawneBombOnRandomCorner(Random.Range(0, 1));//task 2
        }

        
        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            WarpPlayer(enemyTransform, 0.5f); //task 3
        }

        angle = transform.eulerAngles.z;


        if (Keyboard.current.wKey.wasReleasedThisFrame)
        {
            warpDrive(transform.position, 2);
            DetectAteroids(5, asteroidTransforms); //task 4
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

    public void SpawneBombOnRandomCorner(float inDistance)//task 2
    {
        int r = Random.Range(0, 4);
        switch (r)
        {
            case 0:
                GameObject tl = Instantiate(bombPrefab, transform.position + Vector3.up + Vector3.left + new Vector3(-inDistance, inDistance, 0).normalized, Quaternion.identity);

                break;
            case 1:
                GameObject tr = Instantiate(bombPrefab, transform.position + Vector3.up + Vector3.right + new Vector3(inDistance, inDistance, 0).normalized, Quaternion.identity);

                break;

            case 2:
                GameObject bl = Instantiate(bombPrefab, transform.position + Vector3.down + Vector3.left + new Vector3(-inDistance, -inDistance, 0).normalized, Quaternion.identity);

                break;
            case 3:
                GameObject br = Instantiate(bombPrefab, transform.position + Vector3.down + Vector3.right + new Vector3(inDistance, -inDistance, 0).normalized, Quaternion.identity);

                break;
        }
    }
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
                Debug.DrawLine(transform.position, A.position, Color.yellow,10);
            }
        }
    }


}
