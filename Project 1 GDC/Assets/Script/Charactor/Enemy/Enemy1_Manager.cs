using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy1_Manager : MonoBehaviour
{
    public static Enemy1_Manager Instance { get; private set; }
    public GameObject Enemy;

    void Start()
    {
        if (Enemy == null)
        {
            Enemy = GameObject.FindGameObjectWithTag(Constant.ENEMY_TAG);
            if (Enemy == null)
                Debug.LogError("Enemy1_Manager: Enemy not found!");
        }

        if (!Enemy.activeInHierarchy)
        {
            Debug.LogWarning("Enemy is inactive! Re-enabling.");
            Enemy.SetActive(true);
        }
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning("Another instance of Enemy1_Manager already exists. Destroying this one.");
            Destroy(gameObject); // Xóa đối tượng nhưng không ngay lập tức
            return;
        }

        Enemy = GameObject.FindGameObjectWithTag(Constant.ENEMY_TAG);
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public bool enemyIsAlive()
    {
        return Enemy.activeInHierarchy;
    }

    public void TriggerGameOver()
    {
        StartCoroutine(DelayedGameOver());
    }

    private IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
    }
}