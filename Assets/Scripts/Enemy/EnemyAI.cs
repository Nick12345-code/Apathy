using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    private EnemyVision vision;
    private NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private float wanderRadius;
    [SerializeField] private float wanderTimer;
    [SerializeField] private float timer;
    [Header("Animation")]
    private Animator enemyAnimation;
    [SerializeField] private float animationSmoothness;

    // Use this for initialization
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        vision = GetComponent<EnemyVision>();
        enemyAnimation = GetComponentInChildren<Animator>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    private void Update()
    {
        if (vision.canSeePlayer) 
            Chase();
        else if (!vision.canSeePlayer) 
            Wander();

        Animation();
    }

    private void Chase()
    {
        agent.SetDestination(target.position);
    }

    private void Wander()
    {
        // timer increases gradually
        timer += Time.deltaTime;

        // timer is greater than or equal to wanderTimer
        if (timer >= wanderTimer)
        {
            // find random position near this enemy
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);

            // set destination to that position
            agent.SetDestination(newPos);

            // reset timer
            timer = 0;
        }
    }

    // finds a random position within a NavSphere
    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layer)
    {
        // gets a random direction
        Vector3 randDirection = Random.insideUnitSphere * distance;

        // adds the origin as an offset
        randDirection += origin;

        // stores information on what hits NavMesh
        NavMeshHit navHit;

        // tests the position on the NavMesh
        NavMesh.SamplePosition(randDirection, out navHit, distance, layer);

        // returns the random position on the NavMesh
        return navHit.position;
    }

    private void Animation()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            enemyAnimation.SetFloat("Speed", 0.9f, animationSmoothness, Time.deltaTime);
        }
        else if (agent.remainingDistance <= agent.stoppingDistance)
        {
            enemyAnimation.SetFloat("Speed", 0, animationSmoothness, Time.deltaTime);
        }
    }
}
