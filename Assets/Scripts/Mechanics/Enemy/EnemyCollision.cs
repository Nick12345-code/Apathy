using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Health health;
    [Header("Damage Player")]
    [SerializeField] private float timer;
    [SerializeField] private float delay = 1.0f;
    [SerializeField] private MeshRenderer mesh;

    private void Start()
    {
        health = GameObject.Find("PlayerHolder").GetComponent<Health>();
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

    // player loses health when enemy hits them
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.GetComponent<Transform>().CompareTag("Player"))
        {
            health.LoseHealth(10f);
        }
    }

    // player keeps losing health while colliding with enemy
    private void OnCollisionStay(Collision collider)
    {
        if (collider.gameObject.GetComponent<Transform>().CompareTag("Player"))
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
