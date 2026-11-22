using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int maxspeed;
    public float accelTime;
    public float accel;
    public Vector2 playerInput;
    public Vector2 newvelocity;

    public enum FacingDirection
    {
        left, right
    }
    public bool isGrounded;
    public bool isWalking;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        accel = maxspeed / accelTime;
    }

    // Update is called once per frame
    void Update()
    {
        newvelocity = rb.linearVelocity;
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        playerInput = new Vector2();
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x += 1f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x -= 1f;
        }


        if (playerInput.x == 0)
        {
            if (newvelocity.x != 0f)
            {
                //newvelocity = new Vector2(newvelocity.x * 0.9f, 0);
                //that feels nice but now let's try and use the already established variables

                newvelocity = new Vector2(newvelocity.x * (1 - accelTime / maxspeed), 0);

            }
            rb.linearVelocity = newvelocity;

        }
        if (rb.linearVelocity.x > -0.05f && rb.linearVelocity.x < 0.05f)
        {
            rb.linearVelocity = Vector2.zero;
            newvelocity = rb.linearVelocity;

        }

        MovementUpdate(playerInput);
        GetFacingDirection();


        IsGrounded();

    }

    void MovementUpdate(Vector2 playerInput)
    {
        
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
        //bool isWalking = false;
        if (rb.linearVelocity.x != 0)
        {
            return isWalking = true;
        }
        return isWalking = false;
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
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
  
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {

        }
        return FacingDirection.left;
    }
}
