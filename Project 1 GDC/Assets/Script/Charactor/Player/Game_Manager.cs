using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //Script này tạo ra một Singleton
    //Singleton là mẫu thiết kế dùng để tạo ra duy nhất một Instance của cái Class này và cho phép truy cập nó từ mọi nơi
    //thường dùng để lưu các dữ liệu quan trọng và toàn cục
    //chi tiết phải tìm hiểu kỹ

    //ở đây em dùng nó như là một nơi trung gian để lưu vị trí của player

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
        if (Instance == null) //khúc này là để tạo Singleton nhằm đảm bảo chỉ có 1 instance duy nhất trong quá trình chạy,
            Instance = this;      //mấy anh bở qua khúc này cũng được
        else DestroyImmediate(gameObject);

        Player = GameObject.FindGameObjectWithTag(Constant.PLAYER_TAG); //tìm Player trên scene
    }
    void OnDestroy()
    {
        if (Instance == this) //khúc này cũng là tạo Singleton
            Instance = null;
    }

    public bool playerIsAlive()
    {
        if (Player.activeInHierarchy) //nếu Player active trên scene thì Player sống
            return true;
        else return false;
    }
}
