using UnityEngine;

public class Burning : MonoBehaviour
{
    public Health health;

    private void OnTriggerStay(Collider other)
    {
        // if player is touching the fire
        if (other.GetComponentInChildren<CapsuleCollider>().CompareTag("Player"))
        {
            health.losingHealth = true;    
        }
    }

    private void OnTriggerExit(Collider other)
    {
        health.losingHealth = false;
    }
}
