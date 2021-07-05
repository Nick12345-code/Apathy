using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    public Energy energyScript;
    [Header("Light")]
    [SerializeField] private SphereCollider lightRadius;
    [SerializeField] private Light campfireLight;

    private void Update()
    {
        lightRadius.radius = energyScript.energy;
        campfireLight.range = energyScript.energy;
    }
}
