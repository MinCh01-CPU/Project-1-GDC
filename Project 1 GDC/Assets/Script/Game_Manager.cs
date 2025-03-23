using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance {get; private set; }
    public GameObject Player;

    void Awake()
    {
        if (Instance == null)
        Instance = this;
        else DestroyImmediate(gameObject);

        Player = GameObject.FindGameObjectWithTag(Constant.PLAYER_TAG);
    }
    void OnDestroy()
    {
        if (Instance == this)
        Instance = null;
    }

    void Update()
    {
        
    }
    public bool playerIsAlive()
    {
        if(Player.activeInHierarchy)
        return true;
        else return false;
    }
}
