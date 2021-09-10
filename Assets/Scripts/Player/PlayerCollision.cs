using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Wood wood;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // if player collides with a branch
        if (hit.gameObject.CompareTag("Wood"))
        {
            wood.GainWood(1);           
            Destroy(hit.gameObject);    
        }
    }
}
