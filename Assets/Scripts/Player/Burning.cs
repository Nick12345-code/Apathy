using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{
    [Header("Script References")]
    public Health health;
    [Header("Player Burnt")]
    [SerializeField] private float timer;
    [SerializeField] private float delay;

    private void OnTriggerStay(Collider other)
    {
        // if player is touching the fire
        if (other.gameObject.GetComponent<Collider>().CompareTag("Player"))
        {
            // timer increases gradually
            timer += Time.deltaTime;

            // if timer is greater than or equal to delay
            if (timer >= delay)
            {       
                timer = 0.0f;           // timer is reset                                 
                health.LoseHealth(1);   // lose 1 health
            }
        }
    }
}
