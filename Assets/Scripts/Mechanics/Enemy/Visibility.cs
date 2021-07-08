using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    // if within radius of light, enemies stays visible
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    // if out of radius of light, enemies are invisible
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
