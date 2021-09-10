using UnityEngine;

public class Cold : MonoBehaviour
{
    [SerializeField] private Health health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            health.losingHealth = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            health.losingHealth = true;
        }
    }


}
