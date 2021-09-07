using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    [Header("Script References")]
    public Resource resource;
    [Header("Setup")]
    [SerializeField] private float radius;
    [SerializeField] private int woodSpawnedAtOneTime;
    [SerializeField] private GameObject woodPrefab;

    private void Start()
    {
        SpawnWood();
    }

    private void Update()
    {
        // if you have less than 10 wood
        if (resource.wood < 10)
        {
            // if there is more than 30 wood ingame
            if (resource.woodInWorld > 30)
            {
                // don't spawn more
            }
            // else spawn wood
            else
            {
                SpawnWood();
            }
        }
    }

    public GameObject ObjectToSpawn;
    public float RateOfSpawn = 1;

    private float nextSpawn = 0;

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + RateOfSpawn;

            // Random position within this transform
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
            Instantiate(SpawnWood, rndPosWithin, transform.rotation);
        }
    }

    private void SpawnWood()
    {
        // for all wood in woodSpawnedAtOneTime
        for (int i = 0; i < woodSpawnedAtOneTime; i++)
        {
            // temporary spawn position is a random position within a sphere
            Vector2 tempSpawnPosition = Random.cube * radius;

            Vector3 spawnPosition;
            spawnPosition.x = tempSpawnPosition.x;
            spawnPosition.y = 0.1f; // makes sure it spawns on the ground
            spawnPosition.z = tempSpawnPosition.y;

            // spawn wood
            GameObject a = Instantiate(woodPrefab, spawnPosition, Quaternion.identity);
            a.transform.Rotate(90, 0, 0);
            a.transform.SetParent(GameObject.Find("Clones").transform);
        }
        resource.woodInWorld += 10;
    }

    // visualises the area where wood can spawn
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
