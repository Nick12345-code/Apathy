using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Health health;
    [Header("Damaging Player")]
    [SerializeField] private float timer;
    [SerializeField] private float delay = 1.0f;
    [Header("Enemy Visibility")]
    [SerializeField] private MeshRenderer mesh;

    private void Start()
    {
        health = GameObject.Find("PlayerHolder").GetComponent<Health>();
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
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

    // if within radius of light, enemies stays visible
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Light"))
        {
            mesh.enabled = true;
        }
    }

    // if out of radius of light, enemies are invisible
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Light"))
        {
            mesh.enabled = false;
        }
    }
}
