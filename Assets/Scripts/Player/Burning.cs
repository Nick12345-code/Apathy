using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{
    [Header("Script References")]
    public EnemySpawner spawning;
    public Health health;
    public Gold gold;
    [Header("Player Burnt")]
    [SerializeField] private float timer;
    [SerializeField] private float delay;
    [Header("Enemy Burnt")]
    [SerializeField] private GameObject deathEffect;

    private void OnTriggerStay(Collider other)
    {
        // if player is touching the fire
        if (other.gameObject.GetComponent<Collider>().CompareTag("Player"))
        {
            // timer increases gradually
            timer += Time.deltaTime;

            // if timer is greater than or equal to delay
            if (timer >= delay)
            {       
                timer = 0.0f;           // timer is reset                                 
                health.LoseHealth(1);   // lose 1 health
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if enemy is touching fire
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {       
            EnemyDeathEffect(transform.position);   // enable particles
            Destroy(other.gameObject);              // destroy enemy
            spawning.currentAmount--;               // current enemy amount decreased by 1
            gold.GainGold(2);                       // gain 2 gold
        }
    }

    // position to spawn the enemy death particles
    public void EnemyDeathEffect(Vector3 position)
    {
        // spawn particles
        GameObject a = Instantiate(deathEffect, position, transform.rotation) as GameObject;
        a.transform.Rotate(-90, 0, 0);
        a.transform.SetParent(GameObject.Find("Clones").transform);
        // destroy after 5 seconds
        Destroy(a, 5f);
    }
}
