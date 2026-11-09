using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunshipController : MonoBehaviour
{
    public Transform leftCannon;
    public Transform rightCannon;

    public GameObject cannonballPrefab;
    public float cannonballForce = 150f;
    //public Rigidbody2D rb;

    void Update()
    {
        //Takes the mouse position in screen coordinates (pixels) and converts it to world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        //These methods aim the cannons based on where the mouse is in the 2D space
        Vector3 leftDirection = AimCannon(mousePosition, leftCannon);
        Vector3 rightDirection = AimCannon(mousePosition, rightCannon);

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            GameObject cannonBall = Instantiate(cannonballPrefab, rightCannon.position,quaternion.identity);
             
            Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
            Vector3 forceDirection = rightDirection - transform.position;
            rb.AddForce(forceDirection.normalized * cannonballForce );
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject cannonBall = Instantiate(cannonballPrefab, leftCannon.position, quaternion.identity);
            Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
            Vector3 forceDirection = leftDirection - transform.position;
            rb.AddForce(forceDirection.normalized * cannonballForce);
        }
    }

    //Given a target position and the transform of a cannon, aims that cannon at that target
    private Vector3 AimCannon(Vector3 target, Transform cannon)
    {
        Vector3 direction = target - cannon.position;
        //If the z-valids are offset from each other, we don't want the cannons to rotate based on that
        direction.z = 0;

        //Converts the direction that we want to face into an angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
        cannon.eulerAngles = new Vector3(0, 0, angle);

        //We also then finally return the direction that we want to aim based on the target
        return direction;
    }
}
