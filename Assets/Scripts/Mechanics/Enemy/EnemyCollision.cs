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
        health = GameObject.Find("Player").GetComponent<Health>();
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

    private void OnCollisionEnter(Collision collider)
    {
        // if enemy collides with player
        if (collider.gameObject.GetComponent<Transform>().CompareTag("Player"))
        {
            // player loses 5 health
            health.LoseHealth(5f);
        }
    }

    private void OnCollisionStay(Collision collider)
    {
        // if player stays colliding with enemy
        if (collider.gameObject.GetComponent<Transform>().CompareTag("Player"))
        {
            // timer increases gradually
            timer += Time.deltaTime;

            // if timer is greater than or equal to the delay
            if (timer >= delay)
            {
                timer = 0.0f;           // timer is reset
                health.LoseHealth(5f);  // lose 5 health
            }
        }
    }
}
