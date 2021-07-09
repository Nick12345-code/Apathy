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
        #region Enemy Targets & Chases Player
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) >= minDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, target.position) <= maxDistance)
            {

            }
        }
        #endregion
    }
}
