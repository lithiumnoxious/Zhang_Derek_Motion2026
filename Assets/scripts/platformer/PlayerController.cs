using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int maxspeed;
    public float accelTime;
    public float accel;


    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        accel = maxspeed / accelTime;
    }

    // Update is called once per frame
    void Update()
    {

        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        Vector2 playerInput = new Vector2();
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x += 1f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x -= 1f;
        }

        //if (Keyboard.current.upArrowKey.isPressed)
        //{
        //    playerInput = new Vector2(0, 1);
        //}


        MovementUpdate(playerInput);
        GetFacingDirection();


        IsGrounded();

    }

    void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newvelocity = rb.linearVelocity;
        if (playerInput.x != 0f)
        {
            newvelocity += playerInput.x * Vector2.left * accel * Time.deltaTime;
            //newvelocity += playerInput * accel * Time.deltaTime;
        }
        rb.linearVelocity = newvelocity;


    }

    //public static int BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, ContactFilter2D contactFilter, RaycastHit2D[] results, float distance)

    public bool IsWalking()
    {
        bool isWalking = false;
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            isWalking = true;
        }


        return isWalking;
    }
    public bool IsGrounded()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        //bool isGround = true;
        //if (hit)
        //{
        //    isGround = true;
        //}
        //else
        //{
        //    isGround = false;
        //}
        return true; // hit;
    }

    public FacingDirection GetFacingDirection()
    {

        return FacingDirection.left;
    }
}
