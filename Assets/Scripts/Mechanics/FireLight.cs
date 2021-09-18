using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    public Energy energyScript;
    [SerializeField] private Light campfireLight;
    private SphereCollider lightRadius;

    private void Start() => lightRadius = GetComponent<SphereCollider>();

    private void Update() => LoseLight();

    private void LoseLight()
    {
        lightRadius.radius = energyScript.energy;
        campfireLight.range = energyScript.energy;
    }
}
