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
        }

        if (!Player.activeInHierarchy)
        {
            Player.SetActive(true);
        }
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
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
        StartCoroutine(DelayedGameOver());
    }

    private IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(3f); // Đợi 3 giây
        SceneManager.LoadScene(1); // Chuyển về Scene 1
    }
}