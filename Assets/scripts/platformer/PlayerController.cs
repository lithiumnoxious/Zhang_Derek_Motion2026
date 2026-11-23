using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int maxspeed;
    public float accelTime;
    public float accel;
    public float playerinputDirection;

    public bool hasjumped;
     float gravity;
     float initialJumpVelocity;
    public float apexTime;
    public float apexheight;

    public enum FacingDirection
    {
        left, right
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        accel = maxspeed / accelTime;
   

        gravity = -3f * apexheight / (apexTime * apexTime);
        initialJumpVelocity = 2 * apexheight / apexTime;
    }

    // Update is called once per frame
    void Update()
    {
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
     
        //Vector2 playerInput = new Vector2();
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            //playerInput.x += 1f; //was here before the jumping was implemented.
            //playerinputDirection = playerInput.x; //playerinputDirection was placed here so it does not get overwritten
            playerinputDirection = 1; 
            //instead of getting player control into fixed update, I just used playerinputdirection instead of player input.
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerinputDirection = -1;
        }
        else
        {
            playerinputDirection = 0; //resets player direction
        }
        
        if (Keyboard.current.spaceKey.wasPressedThisFrame && IsGrounded())
        {
            hasjumped = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 newvelocity = rb.linearVelocity;
        Vector2 playerInput = new Vector2(playerinputDirection,0); //using playerinputdirection to move left and right
        
        //deceleration
        if (playerInput.x == 0) //if no left or rights are inputed
        {
            if (newvelocity.x != 0f) //if velo is not 0
            {
                //newvelocity = new Vector2(newvelocity.x * 0.9f, newvelocity.y);
                //that feels nice but now let's try and use the already established variables

                newvelocity.x *= 1 - accelTime / maxspeed; 
                //cleaner version,                                   
                //acceltime / maxspeed would equal 0.1, minus 1 equal 0.9, which is a good value for deceleration.
                //I do feel like this could be skipped and just keep 0.9f, as deceleration should not be changed all to often.
            }
            rb.linearVelocity = newvelocity;
        }
        if (rb.linearVelocity.x > -0.05f && rb.linearVelocity.x < 0.05f)
        {
            newvelocity.x = 0;
            rb.linearVelocity = new Vector2(newvelocity.x, rb.linearVelocity.y);
        }

        rb.linearVelocity = newvelocity;

        MovementUpdate(playerInput);
        GetFacingDirection();
        IsGrounded();
    }

    void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newvelocity = rb.linearVelocity;

        if (playerInput.x != 0f) //movement from class
        {
            newvelocity += playerInput.x * Vector2.left * accel* Time.deltaTime;
            //newvelocity += playerInput * accel * Time.deltaTime;
        }

        if (hasjumped)
        {
            newvelocity.y = initialJumpVelocity;
            hasjumped = false;
        }

        newvelocity.y += gravity * Time.fixedDeltaTime;
        rb.linearVelocity = newvelocity;
    }

    public bool IsWalking()
    {
        if (rb.linearVelocity.x != 0)
        {
            return true;
        }
        return false;
    }
    public bool IsGrounded()
    {
        LayerMask mask = LayerMask.GetMask("ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.9f, mask); 
        //ray that shoots down for 0.9f until it hits the ground mask
        //mask is here because it will hit player collider otherwise.

        //if (hit.collider != null) //here to tell me if the ground was hit or not
        //{
        //    Debug.Log("Hit");
        //}
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public FacingDirection GetFacingDirection()
    {
        //playerinputDirection is used to remember what was the last direction playerinput was going
        if (playerinputDirection > 0)
        {
            return FacingDirection.left;
        }
        else 
        { 
            return FacingDirection.right;
        }
    }
}
