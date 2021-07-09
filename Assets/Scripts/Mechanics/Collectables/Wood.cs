using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour
{
    [Header("Script References")]
    public Resource resource;

    private void Start()
    {
        resource = GameObject.Find("Resource").GetComponent<Resource>();
    }

    #region Player Collecting Wood
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            resource.GainWood(1);
            Destroy(this.gameObject);
        }
    }
    #endregion
}
