using UnityEngine;

public class Cold : MonoBehaviour
{
    [SerializeField] private Health health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            StopCoroutine(health.DrainHealth());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            StartCoroutine(health.DrainHealth());
        }
    }


}
