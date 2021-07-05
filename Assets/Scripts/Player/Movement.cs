using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private bool moving = false;
    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRotation;

    private void Update()
    {
        Look();
        if (moving)
        {
            Move();
        }
    }

    private void Look()
    {
        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
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
