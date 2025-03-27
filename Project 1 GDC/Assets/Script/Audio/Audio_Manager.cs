using UnityEngine;

public class Audio_Manager : MonoBehaviour
{

    public AudioSource musicAudioSource;
    public AudioClip shootClip;
    public AudioClip collideClip;

    // Update is called once per frame
    public void PlaySfx(AudioClip clip)
    {
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }
}
