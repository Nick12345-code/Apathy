using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [Header("Script References")]
    public Health health;
    public Gold gold;
    [Header("Player Damage")]
    [SerializeField] private float timer;
    [SerializeField] private float delay;
    [SerializeField] private MeshRenderer mesh;

    private void Start()
    {
        health = GameObject.Find("PlayerHolder").GetComponent<Health>();
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

    private void OnCollisionEnter(Collision collider)
    {
        #region enemy collision with player
        if (collider.gameObject.GetComponent<Transform>().CompareTag("Player"))
        {
            health.LoseHealth(5f);
        }
        #endregion
    }

    #region If Player Keeps Colliding With Enemy
    private void OnCollisionStay(Collision collider)
    {
        if (collider.gameObject.GetComponent<Transform>().CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                timer = 0.0f;
                health.LoseHealth(5f);
            }
        }
    }
    #endregion
}
