using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireSpeed;
    [SerializeField] private float lastTimeFired;

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleShooting();
    }

    #region WASD Movement
    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * -speed * Time.deltaTime, Space.World);
    }
    #endregion

    #region Player Faces Mouse Position
    private void HandleRotation()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
    #endregion

    #region Attacking Enemies
    private void HandleShooting()
    {
        if (Input.GetButton("Fire1"))
        {
            if (lastTimeFired + fireSpeed < Time.time)
            {
                lastTimeFired = Time.time;
                GameObject a = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
                a.transform.SetParent(GameObject.Find("Clones").transform); 
            }
        } 
    }
    #endregion
}
