using UnityEngine;

public class portal : MonoBehaviour
{
    public GameObject player;
    public GameObject portal2;
    public float distance;
    public float teleportTrigger;
    static public bool riftCooldown;
    static public float riftCooldownDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position,player.transform.position);

        if (riftCooldown == false)
        {
            if (distance < teleportTrigger)
            {
                player.transform.position = portal2.transform.position;
                riftCooldownDuration = 0;
                riftCooldown = true;
            }

        }
        else
        {
            riftCooldownDuration += 1 * Time.deltaTime;
            if(riftCooldownDuration >= 5)
            {
                riftCooldown = false;
            }
        }


    }
}
