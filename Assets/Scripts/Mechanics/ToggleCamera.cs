using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    [SerializeField] private GameObject overheadView;

    private void Start()
    {
        overheadView.SetActive(true);
    }

    private void Update()
    {
        #region changing camera view
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!overheadView.activeSelf)
            {
                overheadView.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                overheadView.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        #endregion
    }
}
