using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoking : MonoBehaviour
{
    public Energy energy;
    public Resource resource;
    [Header("Setup")]
    [SerializeField] private GameObject fireStokeEffect;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                print(hit.collider.name);
                if (hit.collider.CompareTag("Campfire"))
                {
                    if (resource.wood > 0)
                    {
                        resource.LoseWood(1);
                        energy.GainEnergy(5);

                        GameObject a = Instantiate(fireStokeEffect, transform.position, Quaternion.identity) as GameObject;
                        a.transform.Rotate(-90, 0, 0);
                        a.transform.SetParent(GameObject.Find("Clones").transform);
                        Destroy(a, 5f);
                    }
                    else
                    {
                        print("You don't have any wood!");
                    }
                }
            }
        }
    }
}
