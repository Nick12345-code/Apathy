using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Wood wood;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // if player collides with wood
        if (hit.gameObject.CompareTag("Wood"))
        {
            wood.GainWood(1);       // player gains 1 wood
            Destroy(hit.gameObject);    // destroy wood GameObject
        }
    }
}
