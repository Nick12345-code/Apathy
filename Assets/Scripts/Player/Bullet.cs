using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    private Gold gold;
    private Burning burning;
    private EnemySpawner spawning;
    [Header("Setup")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speed;
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
        // if distance between the firePoint and bullet is greater than the maxDistance
        if (Vector3.Distance(firePoint.position, transform.position) > maxDistance)
        {
            // destroy bullet
            Destroy(this.gameObject);
        }
        else
        {
            // else bullet moves forward
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if enemy collides with bullet
        if (collision.collider.CompareTag("Enemy"))
        {
            burning.EnemyDeathEffect(transform.position);       // enemy death particles enabled
            Destroy(this.gameObject);                           // destroy bullet
            Destroy(collision.collider.gameObject);             // destroy enemy
            gold.GainGold(5);                                   // gain 5 gold
            spawning.currentAmount--;                           // current amount of enemies decreased by 1
        }
    }
}
