using UnityEngine;

public class Audio_GameOver : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioClip musicClip;

    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }
}
