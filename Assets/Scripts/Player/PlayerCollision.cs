using UnityEngine;
using UnityEngine.SceneManagement;

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

        // if enemy catches player, you lose
        if (hit.gameObject.CompareTag("Enemy")) SceneManager.LoadScene("Lose");
    }
}
