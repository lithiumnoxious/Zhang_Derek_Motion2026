using Unity.VisualScripting;
using UnityEngine;

public class portal : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject portalP;
    public float pDistance;
    public float eDistance;

    public float teleportTrigger = 0.5f;
    static public bool riftCooldown;
    static public float riftCooldownDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pDistance = Vector2.Distance(transform.position,player.transform.position);
        eDistance = Vector2.Distance(transform.position, enemy.transform.position);


        if (riftCooldown == false)
        {
            if (pDistance < teleportTrigger)
            {
                player.transform.position = portalP.transform.position;
                riftCooldownDuration = 0;
                riftCooldown = true;
            }
            if (eDistance < teleportTrigger)
            {
                enemy.transform.position = portalP.transform.position;
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
