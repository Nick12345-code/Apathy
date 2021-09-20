using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Wood woodScript;
    [SerializeField] private Energy energyScript;
    [SerializeField] private AudioController manager;
    [Header("Campfire Interaction")]
    [SerializeField] private float reach;
    [SerializeField] private Transform campfire;
    [SerializeField] private GameObject fireStokeEffect;
    [SerializeField] private GameObject stokeButton;

    private void Update()
    {
        DistanceCheck();
    }

    private void DistanceCheck()
    {
        // if distance between player and campfire is less or equal to reach AND player has wood
        if (Vector3.Distance(transform.position, campfire.position) <= reach && woodScript.wood > 0)
        {
            // stoke button visible
            stokeButton.SetActive(true);
        }
        else
        {
            // stoke button invisible
            stokeButton.SetActive(false);
        }
    }

    public void StokeFire()
    {
        manager.PlaySound(1);
        woodScript.LoseWood(1);
        energyScript.GainEnergy(20);
        StokeParticles();
    }

    private void StokeParticles()
    {
        // spawn particles
        GameObject a = Instantiate(fireStokeEffect, campfire.position, Quaternion.identity) as GameObject;
        // fix their rotation
        a.transform.Rotate(-90, 0, 0);
        // set their parent to clones to keep inspector clean
        a.transform.SetParent(GameObject.Find("Clones").transform);
        // destroy them after 5 seconds
        Destroy(a, 5f);
    }
}
