using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    public Resource resource;
    [Header("Spawning")]
    [SerializeField] private float radius = 5.0f;
    [SerializeField] private int woodSpawnedAtOneTime = 10;
    [SerializeField] private GameObject woodPrefab;

    private void Start()
    {
        SpawnWood();
    }

    private void Update()
    {
        if (resource.wood < 10)
        {
            if (resource.woodInWorld > 30)
            {

            }
            else
            {
                SpawnWood();
            }
        }
    }

    private void SpawnWood()
    {
        for (int i = 0; i < woodSpawnedAtOneTime; i++)
        {
            Vector2 tempSpawnPosition = Random.insideUnitSphere * radius;

            Vector3 spawnPosition;
            spawnPosition.x = tempSpawnPosition.x;
            spawnPosition.y = 0.1f;
            spawnPosition.z = tempSpawnPosition.y;

            GameObject a = Instantiate(woodPrefab, spawnPosition, Quaternion.identity);
            a.transform.Rotate(90, 0, 0);
            a.transform.SetParent(GameObject.Find("Clones").transform);
        }
        resource.woodInWorld += 10;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
