using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timer;
    [SerializeField] private float delay;
    [SerializeField] private float radius;
    [Header("Enemies")]
    [SerializeField] private int spawnAmount;
    [SerializeField] private int maxAmount;
    public int currentAmount;

    private void Update()
    {
        // timer increases gradually
        timer += Time.deltaTime;

        // if timer is greater than or equal to the delay
        if (timer >= delay)
        {
            // timer is reset
            timer = 0.0f;

            // if currentAmount is less than or equal to maxAmount
            if (currentAmount <= maxAmount)
            {
                // spawn enemies
                SpawnEnemies();
            }
            else
            {
                // don't spawn enemies
                print("max number of enemies in play!");
            }
        }
    }

    private void SpawnEnemies()
    {
        // for all enemies in spawnAmount
        for (int i = 0; i < spawnAmount; i++)
        {
            // temporary spawn position is a random point inside a unit sphere
                Vector2 tempSpawnPosition = Random.insideUnitSphere * radius;

                Vector3 spawnPosition;
                spawnPosition.x = tempSpawnPosition.x;
                spawnPosition.y = 30f;  // enemies drop from the sky currently
                spawnPosition.z = tempSpawnPosition.y;
                
                // spawn enemy
                GameObject a = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                a.transform.SetParent(GameObject.Find("Clones").transform); 
        }
        currentAmount += spawnAmount;
    }

    // visually shows area where enemies can spawn
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
