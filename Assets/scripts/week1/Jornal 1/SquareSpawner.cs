using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    public Vector2 mousepos;
    public Vector2 v1 = new Vector2(1, 1);
    public Vector2 v2 = new Vector2(-1, 1);

    public Vector2 v3 = new Vector2(1, -1);
    public Vector2 v4 = new Vector2(-1, -1);
    public Vector2 scroll;
    public Vector2 splus;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.isPressed)
        {
            Debug.DrawLine(mousepos + v1 + splus, mousepos + v2 - splus, new Color(0, 0, 0, 0.7f));
            Debug.DrawLine(mousepos + v2 + splus, mousepos + v4 + splus, new Color(0, 0, 0, 0.7f));
            Debug.DrawLine(mousepos + v3 + splus, mousepos + v1 + splus, new Color(0, 0, 0, 0.7f));
            Debug.DrawLine(mousepos + v4 + splus, mousepos + v3 + splus, new Color(0, 0, 0, 0.7f));
        }


        scroll = Mouse.current.scroll.ReadValue();
        if (scroll.y == 1)
        {
            splus.x++;
            splus.y++;

        }
        if (scroll.y == -1)
        {
            splus.x--;
            splus.y--;

        }

        //scroll.y = Mouse.current.scroll.ReadValue().y;



    }
}
