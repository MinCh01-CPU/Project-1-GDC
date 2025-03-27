using UnityEngine;

public class Audio_Victory : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioClip musicClip;

    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.PlayOneShot(musicClip);
    }
}
