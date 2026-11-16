using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxspeed;
    public float accelTime;
    private float accel;


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
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x -= 1f;
            
        }
        //if (Keyboard.current.upArrowKey.isPressed)
        //{
        //    playerInput = new Vector2(0, 1);
        //}


        MovementUpdate(playerInput);
        GetFacingDirection();
    }

    void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newvelocity = rb.linearVelocity;

        if (playerInput.x != 0f) 
        {
            newvelocity += playerInput.x * Vector2.left * accel * Time.deltaTime;
            //newvelocity += playerInput * accel * Time.deltaTime;

        }
        else
        {
            
        }

        //rb.linearVelocity = Vector2.left * playerInput * maxspeed;
        rb.linearVelocity = newvelocity;

    }

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
       
            return FacingDirection.left;
    }
}
