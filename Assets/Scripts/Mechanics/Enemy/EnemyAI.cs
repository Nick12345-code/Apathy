using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Hostile")]
    private Transform target;
    [SerializeField] private float minDistance = 10.0f;
    [SerializeField] private float maxDistance = 15.0f;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private MeshRenderer mesh;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        mesh.enabled = false;
    }

    #region Comments
    // enemy looks at player
    // if distance between enemy & player is greater than minimum distance
    // enemy travels towards player
    // if distance between enemy & player is less than max distance
    // 
    #endregion
    private void Update()
    {
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) >= minDistance)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, target.position) <= maxDistance)
            {

            }
        }
    }
    
    // if within radius of light, enemies are visible
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Light"))
        {
            mesh.enabled = true;
        }
    }

    // if out of radius of light, enemies are invisible
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Light"))
        {
            mesh.enabled = false;
        }
    }
}
