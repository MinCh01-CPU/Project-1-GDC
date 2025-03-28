using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public GameObject meteoritePrefab; // Prefab của thiên thạch
    public GameObject doubleBulletPowerUpPrefab; // Prefab của vật phẩm x2 đạn
    private float meteoriteSpawnInterval = 2f; // Thời gian giữa các lần thả thiên thạch
    private float powerUpSpawnInterval = 10f; // Thời gian giữa các lần thả vật phẩm

    private Vector3 screenBounds;
    private Audio_Manager audioManager; // Tham chiếu đến Audio_Manager

    void Start()
    {
        // Lấy giới hạn màn hình
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        audioManager = GameObject.FindWithTag(Constant.AUDIO_TAG).GetComponent<Audio_Manager>();
        // Bắt đầu các coroutine thả thiên thạch và vật phẩm
        StartCoroutine(SpawnMeteorites());
        StartCoroutine(SpawnPowerUps());
    }

    System.Collections.IEnumerator SpawnMeteorites()
    {
        while (true)
        {
            yield return new WaitForSeconds(meteoriteSpawnInterval); // Chờ thời gian giữa các lần thả thiên thạch

            // Tạo thiên thạch ở vị trí ngẫu nhiên theo phương ngang
            float randomX = Random.Range(-screenBounds.x, screenBounds.x);
            Vector3 spawnPosition = new Vector3(randomX, screenBounds.y + 1f, 0); // Vị trí trên màn hình
            Instantiate(meteoritePrefab, spawnPosition, Quaternion.identity);
            // Phát âm thanh khi thiên thạch được tạo ra
            if (audioManager != null && audioManager.meteoriteClip != null)
            {
                StartCoroutine(PlayMeteoriteSoundWithDelay(0.3f)); // Delay 0.3 giây
            }
        }
    }
    System.Collections.IEnumerator PlayMeteoriteSoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Chờ 2 giây
        audioManager.PlaySfx(audioManager.meteoriteClip); // Phát âm thanh
    }
    // Coroutine thả vật phẩm x2 đạn
    System.Collections.IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSpawnInterval);

            // Tạo vật phẩm ở vị trí ngẫu nhiên theo phương ngang
            float randomX = Random.Range(-screenBounds.x, screenBounds.x);
            Vector3 spawnPosition = new Vector3(randomX, screenBounds.y + 1f, 0); // Vị trí trên màn hình
            Instantiate(doubleBulletPowerUpPrefab, spawnPosition, Quaternion.identity);
        }
    }
}