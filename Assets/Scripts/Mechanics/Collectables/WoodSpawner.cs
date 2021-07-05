using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] private float radius = 5.0f;
    [SerializeField] private int spawnedWood = 10;
    [SerializeField] private GameObject woodPrefab;

    private void Start()
    {
        SpawnWood();
    }

    private void SpawnWood()
    {
        for (int i = 0; i < spawnedWood; i++)
        {
            Vector2 tempSpawnPosition = Random.insideUnitSphere * radius;

            Vector3 spawnPosition;
            spawnPosition.x = tempSpawnPosition.x;
            spawnPosition.y = 20.0f;
            spawnPosition.z = tempSpawnPosition.y;

            GameObject a = Instantiate(woodPrefab, spawnPosition, Quaternion.identity);
            a.transform.Rotate(90, 0, 0);
            a.transform.SetParent(GameObject.Find("Clones").transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
