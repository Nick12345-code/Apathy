using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour
{
    public Energy energy;
    [Header("Setup")]
    [SerializeField] private int wood = 10;
    [SerializeField] private Text woodText;
    [SerializeField] private GameObject woodPrefab;
    [Header("Spawning")]
    [SerializeField] private float radius = 5.0f;
    [SerializeField] private int spawnedWood = 10;
    [Header("Interaction")]
    [SerializeField] private float range = 10.0f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject fireStokeEffect;

    private void Start()
    {
        woodText.text = wood.ToString();
        SpawnWood();
    }

    private void Update()
    {
        #region collecting wood
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray;
            RaycastHit hitInfo;
            ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, range))
            {
                if (hitInfo.collider.CompareTag("Wood"))
                {
                    GainWood(1);
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
        #endregion

        #region putting wood on campfire
        if (Input.GetButtonDown("Fire2"))
        {
            Ray ray;
            RaycastHit hitInfo;
            ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, range))
            {
                if (hitInfo.collider.CompareTag("Campfire"))
                {
                    if (wood > 0)
                    {
                        #region Fire Stoking Effect
                        GameObject a = Instantiate(fireStokeEffect, transform.position, Quaternion.identity) as GameObject;
                        a.transform.Rotate(-90, 0, 0);
                        a.transform.SetParent(GameObject.Find("Wood").transform);
                        Destroy(a, 5f);
                        #endregion
                        LoseWood(1);
                        energy.GainEnergy(5);
                    }
                    else
                    {
                        print("You don't have any wood!");
                    }
                }
            }
        }
        #endregion
    }

    #region lose/gain wood functions
    public void LoseWood(int amount)
    {
        wood -= amount;
        woodText.text = wood.ToString();
    }

    public void GainWood(int amount)
    {
        wood += amount;
        woodText.text = wood.ToString();
    }
    #endregion

    #region randomly spawning wood
    private void SpawnWood()
    {
        for (int i = 0; i < spawnedWood; i++)
        {
            Vector2 tempSpawnPosition = Random.insideUnitSphere * radius;

            Vector3 spawnPosition;
            spawnPosition.x = tempSpawnPosition.x;
            spawnPosition.y = 20.0f;
            spawnPosition.z = tempSpawnPosition.y;

            GameObject a = Instantiate(woodPrefab, spawnPosition, Quaternion.identity);
            a.transform.Rotate(90, 0, 0);
            a.transform.SetParent(GameObject.Find("WoodHolder").transform);
        }
    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    #endregion
}
