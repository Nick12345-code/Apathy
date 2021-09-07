using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform campfire;
    [SerializeField] private Energy energy;
    [SerializeField] private Resource resource;
    [SerializeField] private GameObject fireStokeEffect;
    [SerializeField] private LayerMask campfireLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StokeFire();
        }
    }

    private void StokeFire()
    {
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, campfireLayer))
        {
            if (hit.collider.CompareTag("Campfire"))
            {
                if (resource.wood > 0)
                {
                    resource.LoseWood(1);
                    energy.GainEnergy(10);

                    StokeParticles();
                }
            }
        }
    }

    private void StokeParticles()
    {
        GameObject a = Instantiate(fireStokeEffect, campfire.position, Quaternion.identity) as GameObject;
        a.transform.Rotate(-90, 0, 0);
        a.transform.SetParent(GameObject.Find("Clones").transform);
        Destroy(a, 5f);
    }
}
