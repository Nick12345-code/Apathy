using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Script References")]
    public Gold gold;
    public Burning burning;
    public EnemySpawner spawning;
    [Header("Setup")]
    [SerializeField] private float speed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float maxDistance;

    private void Start()
    {
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        gold = GameObject.Find("Gold").GetComponent<Gold>();
        burning = GameObject.Find("BurnRadius").GetComponent<Burning>();
        spawning = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        firePoint.position = transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(firePoint.position, transform.position) > maxDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        #region enemy collision with bullet
        if (collision.collider.CompareTag("Enemy"))
        {
            burning.EnemyDeathEffect(transform.position);
            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);
            gold.GainGold(5);
            spawning.currentAmount--;
        }
        #endregion
    }
}
