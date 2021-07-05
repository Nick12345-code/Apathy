using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{
    public Health health;
    [Header("Burning")]
    [SerializeField] private float timer;
    [SerializeField] private float delay = 1.0f;

    #region campfire damages player
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                timer = 0.0f;
                health.LoseHealth(1);
            }
        }
    }
    #endregion
}
