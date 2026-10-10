using UnityEngine;

public class portal : MonoBehaviour
{
    public GameObject portalP;
    public float pDistance;
    public float eDistance;
    public float teleportTrigger = 0.5f;
    static public bool riftCooldown;
    static public float riftCooldownDuration;

    // Update is called once per frame
    void Update()
    {
        pDistance = Vector2.Distance(transform.position, Player.playerPos.position);
        eDistance = Vector2.Distance(transform.position, Enemy.enemyPos.position);

        if (riftCooldown == false)
        {
            if (pDistance < teleportTrigger)
            {
                Player.playerPos.position = portalP.transform.position;
                riftCooldownDuration = 0;
                riftCooldown = true;
            }
            if (eDistance < teleportTrigger)
            {
                Enemy.enemyPos.position = portalP.transform.position;
                riftCooldownDuration = 0;
                riftCooldown = true;
            }
        }
        else
        {
            riftCooldownDuration += 1 * Time.deltaTime;
            if (riftCooldownDuration >= 5)
            {
                riftCooldown = false;
            }
        }


    }
}
