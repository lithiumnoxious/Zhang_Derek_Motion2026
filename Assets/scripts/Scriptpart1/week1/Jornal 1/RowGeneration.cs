using TMPro;
using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    public Vector2 v1 = new Vector2(1, 1);
    public Vector2 v2 = new Vector2(-1, 1);
    public Vector2 v3 = new Vector2(1, -1);
    public Vector2 v4 = new Vector2(-1, -1);
    public TMP_InputField text;
    int num;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

            
        
    }

    public void generate()
    {
        num = int.Parse(text.text);
        Debug.Log(num);
        Vector2 N = new Vector2(0,0);
        //if (num is int)
        //{
            for (int i = 0; i < num; i++)
            {
                Debug.DrawLine(v1 + N, v2 + N, Color.black, 5);
                Debug.DrawLine(v2 + N, v4 + N, Color.black, 5);
                Debug.DrawLine(v3 + N, v1 + N, Color.black, 5);
                Debug.DrawLine(v4 + N, v3 + N, Color.black, 5);
                N.x += 3;
            }
        //}
    }
}
