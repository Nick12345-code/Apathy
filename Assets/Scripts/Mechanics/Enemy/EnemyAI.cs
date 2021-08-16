using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    [SerializeField] private float speed;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        // enemy looks at player
        transform.LookAt(target);

        // if distance between player and enemy is greater than or equal to the minimum distance
        if (Vector3.Distance(transform.position, target.position) >= minDistance)
        {
            // enemy moves forward (towards player)
            transform.position += transform.forward * speed * Time.deltaTime;

            // if distance between player and enemy is less than or equal to the maximum distance
            if (Vector3.Distance(transform.position, target.position) <= maxDistance)
            {
                // IN PROGRESS ...
            }
        }
    }
}
