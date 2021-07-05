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

    private void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            resource.GainWood(1);
            Destroy(this.gameObject);
        }
    }
}
