using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    // enemy is visible when within light
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    // enemy is invisible when not in light
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    
}
