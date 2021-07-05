using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Health health;
    public EnemySpawner spawning;
    [SerializeField] private GameObject deathEffect;
    [Header("Damaging Player")]
    [SerializeField] private float timer;
    [SerializeField] private float delay = 1.0f;

    private void Start()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
        spawning = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    #region enemy collisions
    private void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.GetComponent<Collider>().CompareTag("Campfire"))
        {
            GameObject a = Instantiate(deathEffect, transform.position, transform.rotation) as GameObject;
            a.transform.Rotate(-90, 0, 0);
            a.transform.SetParent(GameObject.Find("Enemies").transform);
            Destroy(a, 5f);

            Destroy(transform.parent.gameObject);
            spawning.currentAmount--;
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.GetComponent<Collider>().CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                timer = 0.0f;
                health.LoseHealth(10f);
            }
        }
    }
    #endregion
}
