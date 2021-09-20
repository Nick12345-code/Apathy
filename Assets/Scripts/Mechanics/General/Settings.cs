using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer mixer;    
    public Slider volumeSlider;
    public float sliderpercentage;

    private void Start()
    {
        if (!volumeSlider) volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
    }

    public void SetVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
        mixer.SetFloat("Volume", Mathf.Log10(value) * 20);
    }
}
