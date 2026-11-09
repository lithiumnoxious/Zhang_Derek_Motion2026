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
        target = targetSelect();
    }

    // Update is called once per frame
    void Update()
    {
        arrivalDistance = Vector3.Distance(transform.position, target);
        Move();

        if (arrivalDistance < 0.5f)
        {
            target = targetSelect();
        }
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
    public float distancePick()
    {
        float r = Random.Range(-maxFloatDistance, maxFloatDistance);
        return (r);
    }
    public Vector3 targetSelect()
    {
        Vector3 temp = new Vector3(transform.position.x + distancePick(), transform.position.y + distancePick(), 0);
        return (temp);
    }
}
