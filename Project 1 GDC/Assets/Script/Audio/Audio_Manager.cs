using UnityEngine;

public class Audio_Manager : MonoBehaviour
{

    public AudioSource musicAudioSource;
    public AudioClip shootClip; // tiếng bắn súng
    public AudioClip collideClip; // tiếng va chạm
    public AudioClip meteoriteClip; // tiếng thiên thạch rơi

    // Update is called once per frame
    public void PlaySfx(AudioClip clip)
    {
        if (clip != null)
        {
            musicAudioSource.PlayOneShot(clip); // Phát âm thanh mà không ghi đè
        }
    }
}
