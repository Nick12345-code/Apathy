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
        #region Enemy Spawn Timer
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
        #endregion
    }

    #region Enemy Spawning
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
                a.transform.SetParent(GameObject.Find("Clones").transform); 
        }
        currentAmount += spawnAmount;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    #endregion
}
