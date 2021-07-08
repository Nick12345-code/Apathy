using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour
{
    public Resource resource;

    private void Start()
    {
        resource = GameObject.Find("Resource").GetComponent<Resource>();
    }

    // if player collides with branch, wood increases
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            resource.GainWood(1);
            Destroy(this.gameObject);
        }
    }
}
