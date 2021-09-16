using UnityEngine;

public class Cold : MonoBehaviour
{
    [SerializeField] private Health health;
    Collider other;

    // if entering radius of campfire light
    private void OnTriggerEnter(Collider other)
    {
        // if is the player
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            // player doesn't lose health
            health.losingHealth = false;
            this.other = other;
        }
    }

    // if exiting radius of campfire light
    private void OnTriggerExit(Collider other)
    {
        // if is the player
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            // player starts losing health
            health.losingHealth = true;
        }
    }

    private void Update()
    {
        if (!other)
        {
            // player starts losing health
            health.losingHealth = true;
        }
    }


}
