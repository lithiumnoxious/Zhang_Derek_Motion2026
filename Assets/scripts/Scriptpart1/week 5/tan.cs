using UnityEngine;

public class tan : MonoBehaviour
{
    //public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float firstAngle = 45f;
        //float secondAngle = 325f;

        //float firstVectorX = Mathf.Cos(45f * Mathf.Deg2Rad);
        //float secondVectorX = Mathf.Cos(325f * Mathf.Deg2Rad);

        //Debug.Log(firstVectorX);
        //Debug.Log(secondVectorX);


        //Debug.Log(vectortoangle(player.transform.position));

    }

    // Update is called once per frame
    void Update()
    {
        



    }

    public static float vectortoangle(Vector3 vector)
    {
        float angle = Mathf.Atan2 (vector.y, vector.x) * Mathf.Rad2Deg;

        return angle - 90f;
    }
}
