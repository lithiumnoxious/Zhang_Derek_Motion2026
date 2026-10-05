using Unity.VisualScripting;
using UnityEngine;

public class portallspawner : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;
    public GameObject playerPos;
    public GameObject enemypos;
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
            Vector3 riftpos = new Vector3(Random.Range(0, spawnRange), Random.Range(0, spawnRange),0);
            GameObject rift1 = Instantiate(portal1,riftpos, Quaternion.identity);
            GameObject rift2 = Instantiate(portal1, -riftpos, Quaternion.identity);

            portal script1 = rift1.GetComponent<portal>();
            portal script2 = rift2.GetComponent<portal>();
            script1.player = playerPos;
            script1.enemy = enemypos;

            script2.player = playerPos;
            script2.enemy = enemypos;


            script1.portalP = rift1;

            script2.portalP = rift2;

            Destroy (rift1,5);
            Destroy (rift2,5);


            PortalSpawnTimer = 0;
        }



    }
}
