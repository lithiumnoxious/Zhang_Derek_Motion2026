using UnityEngine;

public class DrawingVectors : MonoBehaviour
{
    Vector2 dVector = new Vector2(0, 3);
    Vector2 eVector = new Vector2(3, 0);
    Vector2 fVector = new Vector2 (3, 3);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawLine(dVector, eVector, Color.yellow);
        Debug.DrawLine(eVector, fVector, Color.gray);
        Debug.DrawLine(fVector, dVector, Color.blue);


    }

}
