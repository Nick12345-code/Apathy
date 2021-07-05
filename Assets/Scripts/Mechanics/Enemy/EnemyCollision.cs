using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Health health;
    [Header("Damaging Player")]
    [SerializeField] private float timer;
    [SerializeField] private float delay = 1.0f;

    private void Start()
    {
        health = GameObject.Find("PlayerHolder").GetComponent<Health>();
    }

    private void OnCollisionStay(Collision collider)
    {
        if (collider.gameObject.GetComponent<Rigidbody>().CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                timer = 0.0f;
                health.LoseHealth(10f);
            }
        }
    }
}
