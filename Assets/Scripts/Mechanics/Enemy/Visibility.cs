using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    #region Enemy Is Visible When In Light
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    #endregion

    #region Enemy Is Invisible When Out Of Light
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().CompareTag("Enemy"))
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    #endregion
}
