using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{
    [Header("Script References")]
    public EnemySpawner spawning;
    public Health health;
    public Gold gold;
    [Header("Player Burnt")]
    [SerializeField] private float timer;
    [SerializeField] private float delay;
    [Header("Enemy Burnt")]
    [SerializeField] private GameObject deathEffect;

    #region Player Burnt
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                timer = 0.0f;
                health.LoseHealth(1);
                Tips.tips.text = "You are being burned!";
            }
        }
    }
    #endregion

    #region Enemy Burnt
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {
            EnemyDeathEffect(transform.position);
            Destroy(other.gameObject);
            spawning.currentAmount--;
            gold.GainGold(2);
        }
    }
    #endregion

    public void EnemyDeathEffect(Vector3 position)
    {
        GameObject a = Instantiate(deathEffect, position, transform.rotation) as GameObject;
        a.transform.Rotate(-90, 0, 0);
        a.transform.SetParent(GameObject.Find("Clones").transform);
        Destroy(a, 5f);
    }
}
