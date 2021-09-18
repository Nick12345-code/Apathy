using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Wood wood;
    [SerializeField] private Health health;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // if player collides with a branch
        if (hit.gameObject.CompareTag("Wood"))
        {
            wood.GainWood(1);           
            Destroy(hit.gameObject);    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            health.losingHealth = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
