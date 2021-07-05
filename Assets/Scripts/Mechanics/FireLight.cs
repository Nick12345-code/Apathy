using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    public Energy energyScript;
    [Header("Light")]
    [SerializeField] private SphereCollider lightRadius;
    [SerializeField] private Light campfireLight;
    [Header("Enemy Visibility")]
    [SerializeField] private MeshRenderer mesh;

    private void Start()
    {
        mesh.enabled = false;
    }

    private void Update()
    {
        lightRadius.radius = energyScript.energy;
        campfireLight.range = energyScript.energy;
    }

    // if within radius of light, enemies are visible
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {
            mesh.enabled = true;
        }
    }

    // if out of radius of light, enemies are invisible
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {
            mesh.enabled = false;
        }
    }
}
