using UnityEngine;

public class portallspawner : MonoBehaviour
{
    public GameObject portal;
    public float PortalSpawnTimer;
    public float PortalTimerDelay;
    public int publicDifficulty;
    public static int difficulty;
    public float colordifference;

    void Start()
    {
        if (difficulty <= 0)
        {
            difficulty = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (difficulty != publicDifficulty)
        {
            difficulty = publicDifficulty;
        }
        PortalSpawnTimer += 1 * Time.deltaTime * difficulty;
        if (PortalSpawnTimer >= PortalTimerDelay)
        {
            Vector3 riftpos = new Vector3(
                    Random.Range(-Radar.SpawnRange, Radar.SpawnRange),
                    Random.Range(-Radar.SpawnRange, Radar.SpawnRange), 0);
            GameObject rift1 = Instantiate(portal, riftpos, Quaternion.identity);
            GameObject rift2 = Instantiate(portal, -riftpos, Quaternion.identity);

            SpriteRenderer sr1 = rift1.GetComponent<SpriteRenderer>();
            SpriteRenderer sr2 = rift2.GetComponent<SpriteRenderer>();

            portal script1 = rift1.GetComponent<portal>();
            portal script2 = rift2.GetComponent<portal>();

            int r = Random.Range(0, 3);
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

            Destroy(rift1, PortalTimerDelay / difficulty);
            Destroy(rift2, PortalTimerDelay / difficulty);
            PortalSpawnTimer = 0;
        }
    }
}
