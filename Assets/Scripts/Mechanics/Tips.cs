using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tips : MonoBehaviour
{
    public static TextMeshProUGUI tips;

    private void Start()
    {
        tips = GetComponent<TextMeshProUGUI>();
    }

    // when a tip is shown, it turns off after a few seconds
    private void Update()
    {
        if (tips.text != "")
        {
            Invoke("TipOff", 2f);
        }
    }

    private void TipOff()
    {
        tips.text = "";
    }
}
