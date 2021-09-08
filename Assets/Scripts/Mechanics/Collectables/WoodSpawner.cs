using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    private Wood wood;
    [SerializeField] private GameObject branch;
    [SerializeField] private int maxBranches;
    [SerializeField] private float spawnRate = 1;
    private float nextSpawn = 0;

    private void Start()
    {
        wood = GetComponent<Wood>();
    }

    private void Update()
    {
        // if there is more than 30 wood ingame
        if (wood.woodInWorld >= maxBranches) print("too many branches in the world!");
        // else spawn wood
        else SpawnWood();
    }

    private void SpawnWood()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;

            // random position within this transform
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);

            // spawn branches
            GameObject a = Instantiate(branch, rndPosWithin, Quaternion.identity);
            a.transform.Rotate(90, 0, 0);
            a.transform.SetParent(GameObject.Find("Clones").transform);
            wood.woodInWorld += 1;
        }
    }
}
