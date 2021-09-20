using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip[] sfx;
    [SerializeField] private AudioClip[] music;
    [SerializeField] private bool isPlaying;

    [SerializeField] private float audio1Volume;
    [SerializeField] private float audio2Volume;

    public void PlaySound(int index)
    {
        sfxSource.PlayOneShot(sfx[index]);
    }

    private void Update()
    {
        if (audio1Volume <= 0.1)
        {
            if (isPlaying == false)
            {
                isPlaying = true;
                musicSource.clip = music[0];
                musicSource.Play();
            }
        }
    }

    public void FadeIn()
    {
        if (audio2Volume < 1)
        {
            audio2Volume += 0.1f * Time.deltaTime;
            musicSource.volume = audio2Volume;
        }
    }

    public void FadeOut()
    {
        if (audio2Volume > 0)
        {
            audio2Volume -= 0.1f * Time.deltaTime;
            musicSource.volume = audio2Volume;
        }
    }
}
