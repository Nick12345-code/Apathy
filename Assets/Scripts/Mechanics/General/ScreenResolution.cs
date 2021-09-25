using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    private void Start() => Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
}
