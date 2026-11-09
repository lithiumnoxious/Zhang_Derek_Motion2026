using UnityEngine;
using UnityEngine.InputSystem;

public class vetormath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //drawsquare(mousepos,5,Color.red,10);


        //transform.up is the static upward direction of the game object
        //Vector2.up is the static upward direction of the scene
        //methods / functions can also be static
        //vector offset is the act of adding two vectors together
    }

    public static float Gemag(Vector2 Vector)
    {

        return Mathf.Sqrt(Vector.x * Vector.x + Vector.y * Vector.y);
    }

    public static void drawsquare(Vector2 cent, float size, Color colour, float duration)
    {
        //top line
        Vector2 startpnt = cent + new Vector2(-size, size);
        Vector2 sndpnt = cent + new Vector2(size, size);

        Debug.DrawLine(startpnt, sndpnt, colour, duration);

        //left line
        startpnt = cent + new Vector2(-size, size);
        sndpnt = cent + new Vector2(-size, -size);

        Debug.DrawLine(startpnt, sndpnt, colour, duration);

        //bottom line
        startpnt = cent + new Vector2(-size, -size);
        sndpnt = cent + new Vector2(size, -size);

        Debug.DrawLine(startpnt, sndpnt, colour, duration);

        //right line
        startpnt = cent + new Vector2(size, -size);
        sndpnt = cent + new Vector2(size, size);

        Debug.DrawLine(startpnt, sndpnt, colour, duration);


    }
    public static Vector2 normlise(Vector2 vector)
    {
        float vectorsize = Gemag(vector);
        Vector2 normaliseVector = new Vector2(vector.x, vector.y) / vectorsize;

        return normaliseVector;
    }

}
