using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Stoking Fire")]
    [SerializeField] private float reach;
    [SerializeField] private Transform campfire;
    [SerializeField] private Energy energy;
    [SerializeField] private Wood woodScript;
    [SerializeField] private GameObject fireStokeEffect;
    [SerializeField] private GameObject stokeButton;

    private void Update()
    {
        DistanceCheck();
    }
    
    private void DistanceCheck()
    {
        if (Vector3.Distance(transform.position, campfire.position) <= reach && woodScript.wood > 0)
        {
            stokeButton.SetActive(true);
        }
        else
        {
            stokeButton.SetActive(false);
        }
    }

    public void StokeFire()
    {
        if (woodScript.wood > 0)
        {
            woodScript.LoseWood(1);
            energy.GainEnergy(10);
            StokeParticles();
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
