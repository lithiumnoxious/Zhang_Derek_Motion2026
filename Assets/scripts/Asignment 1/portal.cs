using UnityEngine;

public class portal : MonoBehaviour
{
    //public GameObject player;
    //public GameObject enemy;
    public GameObject portalP;
    public float pDistance;
    public float eDistance;

    public float teleportTrigger = 0.5f;
    static public bool riftCooldown;
    static public float riftCooldownDuration;
    //public bool differentiateColor;
    //SpriteRenderer sr;
    //Color c;
    //float r; float g; float b;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //sr = GetComponent<SpriteRenderer>();
        //int r = Random.Range(0, 2);
        

        //switch (r)
        //{
        //    case 0:
        //        sr.color = Color.red;
        //        c = sr.color;
        //        break;
        //    case 1:
        //        sr.color = Color.blue;
        //        c = sr.color;
        //        break;
        //    case 2:
        //        sr.color = Color.green;
        //        c = sr.color;
        //        break;
        //}
        //if (differentiateColor)
        //{
        //    sr.color = c * portallspawner.colordifference;
        //}
   
            



        //r = Random.Range(0.5f, 1);
        //g = Random.Range(0.5f, 1);
        //b = Random.Range(0.5f, 1);
        //sr.color = new Color(r, g, b);
        //c = sr.color;

        //if (differentiateColor)
        //{
        //    //sr.color = Color.red;
        //    c = new Color(r - 0.2f, g - 0.2f, b - 0.2f);
        //    sr.color = c;
        //}





    }

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
