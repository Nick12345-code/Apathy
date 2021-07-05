using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    public Energy energyScript;
    [Header("Light")]
    [SerializeField] private SphereCollider lightRadius;
    [SerializeField] private int weakLight = 25;
    [SerializeField] private int normalLight = 50;
    [SerializeField] private int strongLight = 100;
    [SerializeField] private Light campfireLight;

    private void Update()
    {
        #region range of light is dependant on energy level
        lightRadius.radius = energyScript.energy;
        campfireLight.range = energyScript.energy;
        #endregion
    }
}
