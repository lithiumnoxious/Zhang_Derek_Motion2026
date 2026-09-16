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
    public Vector3 Offset;

    void Update()
    {
        if (Keyboard.current.bKey.wasReleasedThisFrame)
        {
            //when b key is pressed the bomb will be instantiated
            //we use gameobject's transfrom.position + the amount i want it to be off setted by, in our case it's 2
            //spawnbomboffset(transform.position + new Vector3(0,2,0));

            SpawnBombAtOffset(Offset);//task 1
        }
        if (Keyboard.current.wKey.wasReleasedThisFrame)
        {
            //when w key is pressed ship will move forward
            //we use gameobject's simularly to the bomb but we off set during the method
            //the float is the speed / amount the ship is moving forwards by
            warpDrive(transform.position, 0.5f);
        }
        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
           
            WarpPlayer(transform.position,enemyTransform.position, 0.5f);
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

    }

    public IEnumerator die(GameObject bob)
    {
        //bomb is delayed for 3 seconds but still destroyed
        Destroy(bob,3);
        //says bomba so I know it works
        Debug.Log("bomba");

        yield return (null);
    }

    public void warpDrive(Vector3 ship, float speed)
    {
        //detects if speed is too high or too low before the rest of the code
        //locks it back down.
        if (speed > 1)
        {
            speed = 1;
        }
        if (speed < 0)
        {
            speed = 0;
        }
        //vector3 of ship instead of transform.pos is here because trans.pos can not to adjusted like how i am using it for
        ship.y += speed;
        //match the new ship vector with the actual gameobj pos
        transform.position = ship;
    }
    public void WarpPlayer(Vector2 ship,Vector2 enemy, float speed)
    {
        if (speed > 1)
        {
            speed = 1;
        }
        if (speed < 0)
        {
            speed = 0;
        }

        ship = Vector3.Lerp(ship,enemy,speed);



        transform.position = ship;
    }
}
