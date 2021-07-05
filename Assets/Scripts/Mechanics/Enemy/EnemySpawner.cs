using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timer;
    [SerializeField] private float delay = 1.0f;
    [SerializeField] private float radius = 25f;
    [Header("Enemies")]
    [SerializeField] private int spawnAmount = 5;
    public int currentAmount = 0;
    [SerializeField] private int maxAmount = 10;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            timer = 0.0f;
            if (currentAmount <= maxAmount)
            {
                SpawnEnemies();
            }
            else
            {
                print("max number of enemies in play!");
            }
        }
    }

    #region Comments
    // for every enemy in spawned enemies
    // spawn randomly within a sphere
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    #endregion
    private void SpawnEnemies()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
                Vector2 tempSpawnPosition = Random.insideUnitSphere * radius;

                Vector3 spawnPosition;
                spawnPosition.x = tempSpawnPosition.x;
                spawnPosition.y = 30f;
                spawnPosition.z = tempSpawnPosition.y;

                GameObject a = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                a.transform.SetParent(GameObject.Find("Enemies").transform); 
        }
        currentAmount += spawnAmount;
    }
}
