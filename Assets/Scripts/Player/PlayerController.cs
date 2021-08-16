using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Mana manaScript;
    [Header("Movement")]
    [SerializeField] private float speed;
    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireSpeed;
    [SerializeField] private float lastTimeFired;
    [SerializeField] private float shootCost;

    private void Update()
    {
        Movement();
        Rotation();
        Shooting();
    }

    private void Movement()
    {
        // WASD movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * -speed * Time.deltaTime, Space.World);
    }

    private void Rotation()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    private void Shooting()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (Input.GetButton("Fire1"))
            {
                if (manaScript.mana >= shootCost)
                {
                    Shoot(); 
                }
            } 
        }

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
           
        }
    }

    private void Shoot()
    {
        if (lastTimeFired + fireSpeed < Time.time)
        {
            lastTimeFired = Time.time;
            GameObject a = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
            a.transform.SetParent(GameObject.Find("Clones").transform);
            manaScript.LoseMana(shootCost);
        }
    }
}
