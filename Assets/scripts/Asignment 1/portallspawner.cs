using Unity.VisualScripting;
using UnityEngine;

public class portallspawner : MonoBehaviour
{
    public GameObject portal;
    //public GameObject portal2;
    //public GameObject playerPos;
    //public GameObject enemypos;
    public float PortalSpawnTimer;
    public float PortalTimerDelay;


    public float difficulty;
    public float spawnRange;
    //public portal p;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        PortalSpawnTimer += 1 * Time.deltaTime * difficulty;
        if (PortalSpawnTimer >= 5)
        {



            Vector3 riftpos = new Vector3(Random.Range(0, spawnRange) + spawnRange/2, Random.Range(0, spawnRange) + spawnRange/2,0);
            GameObject rift1 = Instantiate(portal,riftpos, Quaternion.identity);
            GameObject rift2 = Instantiate(portal, -riftpos, Quaternion.identity);

            //SpriteRenderer sr1 = rift1.GetComponent<SpriteRenderer>();
            //SpriteRenderer sr2 = rift2.GetComponent<SpriteRenderer>();
            //sr1.color = new Color(Random.Range(0,200), Random.Range(0, 200), Random.Range(0, 200));
            //sr2.color = new Color(Random.Range(0, 200), Random.Range(0, 200), Random.Range(0, 200));


            portal script1 = rift1.GetComponent<portal>();
            portal script2 = rift2.GetComponent<portal>();
            script2.differentiateColor = true;

            //script1.player = playerPos;
            //script1.enemy = enemypos;

            //script2.player = playerPos;
            //script2.enemy = enemypos;


            script1.portalP = rift2;
            script2.portalP = rift1;

            Destroy (rift1,5/difficulty);
            Destroy (rift2,5/difficulty);
            PortalSpawnTimer = 0;
        }



    }
}
