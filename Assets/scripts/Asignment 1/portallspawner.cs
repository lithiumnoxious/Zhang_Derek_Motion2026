using UnityEngine;

public class portallspawner : MonoBehaviour
{
    public GameObject portal;

    public float PortalSpawnTimer;
    public float PortalTimerDelay;
    public float difficulty;
    public float spawnRange;

    public float colordifference;
   
    // Update is called once per frame
    void Update()
    {

        PortalSpawnTimer += 1 * Time.deltaTime * difficulty;
        if (PortalSpawnTimer >= 5)
        {
            Vector3 riftpos = new Vector3(Random.Range(0, spawnRange) + spawnRange / 2, Random.Range(0, spawnRange) + spawnRange / 2, 0);
            GameObject rift1 = Instantiate(portal, riftpos, Quaternion.identity);
            GameObject rift2 = Instantiate(portal, -riftpos, Quaternion.identity);

            SpriteRenderer sr1 = rift1.GetComponent<SpriteRenderer>();
            SpriteRenderer sr2 = rift2.GetComponent<SpriteRenderer>();
 
            portal script1 = rift1.GetComponent<portal>();
            portal script2 = rift2.GetComponent<portal>();

            int r = Random.Range(0, 2);
            switch (r)
            {
                case 0:
                    sr1.color = Color.red;
                    sr2.color = Color.red * colordifference;
                    break;
                case 1:
                    sr1.color = Color.blue;
                    sr2.color = Color.blue * colordifference;
                    break;
                case 2:
                    sr1.color = Color.green;
                    sr2.color = Color.green * colordifference;
                    break;
            }

            script1.portalP = rift2;
            script2.portalP = rift1;

            Destroy(rift1, 5 / difficulty);
            Destroy(rift2, 5 / difficulty);
            PortalSpawnTimer = 0;
        }
    }
}
