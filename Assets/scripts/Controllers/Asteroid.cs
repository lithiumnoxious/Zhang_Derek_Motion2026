using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    public float timer;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arrivalDistance = Vector3.Distance(transform.position, target);

        if (timer >= 5)
        {
            target = new Vector3(transform.position.x + distancePick(), transform.position.y + distancePick(), 0);
            StartCoroutine(Move());
            timer = 0;
        }
        timer += Time.deltaTime;
        

    }

    public float distancePick()
    {
        float r = Random.Range(0,maxFloatDistance);
        return (r);
    }

    public IEnumerator Move()
    {
        float step = moveSpeed * Time.deltaTime;
        while (arrivalDistance > 0.5f)
        {
            transform.position += Vector3.MoveTowards(transform.position, target, step);
        }


        yield return null;
    }
}
