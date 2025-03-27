using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance { get; private set; }
    public GameObject Player;

    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag(Constant.PLAYER_TAG);
            if (Player == null)
                Debug.LogError("Game_Manager: Player not found!");
        }

        if (!Player.activeInHierarchy)
        {
            Debug.LogWarning("Player is inactive! Re-enabling.");
            Player.SetActive(true);
        }
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning("Another instance of Game_Manager already exists. Destroying this one.");
            Destroy(gameObject); // Xóa đối tượng nhưng không ngay lập tức
            return;
        }

        Player = GameObject.FindGameObjectWithTag(Constant.PLAYER_TAG);
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public bool playerIsAlive()
    {
        return Player.activeInHierarchy;
    }

    public void TriggerGameOver()
    {
        Debug.Log("Game Over triggered!");
        StartCoroutine(DelayedGameOver());
    }

    private IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(3f); // Đợi 3 giây
        Debug.Log("Loading Scene 1...");
        SceneManager.LoadScene(1); // Chuyển về Scene 1
    }
}