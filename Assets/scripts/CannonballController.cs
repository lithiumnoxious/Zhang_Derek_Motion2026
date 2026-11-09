using UnityEngine;

public class CannonballController : MonoBehaviour
{
    public float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        //After lifespan seconds, this object will be destroyed
        Destroy(gameObject, lifespan);
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            Debug.Log("explode");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreboardController.score++;
        }
        if (collision.gameObject.tag == "CBall")
        {
            Debug.Log("Ball explode");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }


    }
    
}
