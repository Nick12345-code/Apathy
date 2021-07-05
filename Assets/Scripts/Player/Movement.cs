using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private bool moving = false;
    [SerializeField] private LayerMask groundLayer;
    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRotation;

    private void Update()
    {
        if (!moving)
        {
            Look();
        }

        if (moving)
        {
            Move();
        }
    }

    private void Look()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, groundLayer))
            {
                if (hit.collider.CompareTag("Ground"))
                {                   
                    targetPosition = hit.point;
                    this.transform.LookAt(targetPosition);
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                    lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
                    playerRotation = Quaternion.LookRotation(lookAtTarget);
                    moving = true;
                }
                else
                {
                    print("you can't move here!");
                }
            }
        }
    }

    private void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            moving = false;
        }
    }
}
