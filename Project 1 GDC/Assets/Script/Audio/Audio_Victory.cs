using UnityEngine;

public class Audio_Victory : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioClip musicClip;

    void Start()
    {
        StartCoroutine(PlayVictoryMusicWithDelay(1f)); // Gọi coroutine để phát âm thanh sau 1 giây
    }
    System.Collections.IEnumerator PlayVictoryMusicWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Chờ 2 giây
        musicAudioSource.clip = musicClip;
        musicAudioSource.PlayOneShot(musicClip); // Phát âm thanh
    }
}
