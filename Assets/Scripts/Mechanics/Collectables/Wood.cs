using UnityEngine;

public class Wood : MonoBehaviour
{
    [Header("Script References")]
    public Resource resource;

    private void Start()
    {
        resource = GameObject.Find("Resource").GetComponent<Resource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if player collides with wood
        if(other.gameObject.CompareTag("Player"))
        {
            resource.GainWood(1);       // player gains 1 wood
            Destroy(this.gameObject);   // destroy wood GameObject
        }
    }
}
