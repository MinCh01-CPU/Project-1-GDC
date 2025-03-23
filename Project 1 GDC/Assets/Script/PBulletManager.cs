using System.Collections.Generic;
using UnityEngine;

public class PBulletManager : MonoBehaviour
{
    //Cái Script này dùng để tạo một loạt các viên đạn nằm chờ sẵn ở trong scene, ý tưởng ở đây là
    //mình không tạo một viên đạn rồi xóa đi viên đạn đó nếu trúng mục tiêu hay đi quá xa, mà mình sẽ
    //tạo sẵn các viên đạn trước rồi khi bắn, ta bật nó lên mà khi trúng thì ta tắt nó đi
    
    //Cái Script này dùng để quản lý các viên đạn của người chơi
    public GameObject playerBullet;
    public List<GameObject> playerBullets;
    public float storedBulletAmount;
   
    void Start()
    {
        GameObject tmp;
        for (int i = 0; i < storedBulletAmount; i++)
        {
            tmp = Instantiate(playerBullet);
            tmp.SetActive(false);
            playerBullets.Add(tmp);
        }
    }
    public GameObject fireBullet()
    {
        for (int i = 0; i < storedBulletAmount; i++)
        {
            if (!playerBullets[i].activeInHierarchy)
            return playerBullets[i];
        }
        return null;
    }
}
