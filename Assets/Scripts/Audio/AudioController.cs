using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip[] sfx;
    [SerializeField] private AudioClip[] music;

    private void Start()
    {
        musicSource.clip = music[0];
        musicSource.Play();
        musicSource.volume = 0;
    }

    public void PlaySound(int index)
    {
        sfxSource.PlayOneShot(sfx[index]);
    }

    public void FadeIn()
    {
        if (musicSource.volume < 1)
        {
            musicSource.volume += 1f * Time.deltaTime;
        }
    }

    public void FadeOut()
    {
        if (musicSource.volume > 0)
        {
            musicSource.volume -= 0.1f * Time.deltaTime;
        }
    }
}
