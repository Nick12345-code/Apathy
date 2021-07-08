using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{
    public EnemySpawner spawning;
    public Health health;
    [Header("Player Burning")]
    [SerializeField] private float timer;
    [SerializeField] private float delay = 1.0f;
    [Header("Enemy Burning")]
    [SerializeField] private GameObject deathEffect;

    // player
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                timer = 0.0f;
                health.LoseHealth(1);
                Tips.tips.text = "You are being burned!";
            }
        }
    }

    // enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {
            GameObject a = Instantiate(deathEffect, transform.position, transform.rotation) as GameObject;
            a.transform.Rotate(-90, 0, 0);
            a.transform.SetParent(GameObject.Find("Clones").transform);
            Destroy(a, 5f);

            Destroy(other.gameObject);
            spawning.currentAmount--;
        }
    }
}
