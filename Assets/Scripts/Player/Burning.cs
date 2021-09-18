using UnityEngine;

public class Burning : MonoBehaviour
{
    public Health health;

    private void OnTriggerEnter(Collider other)
    {
        // if player is touching the fire
        if (other.CompareTag("Player"))
        {
            health.losingHealth = true;    
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if player leaves the fire
        if (other.CompareTag("Player"))
        {
            health.losingHealth = false;
        }
    }
}
