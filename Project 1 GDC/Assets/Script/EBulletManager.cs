using UnityEngine;
using System.Collections.Generic;

public class EBulletManager : MonoBehaviour
{   
    //Cái Script này dùng để tạo một loạt các viên đạn nằm chờ sẵn ở trong scene, ý tưởng ở đây là
    //mình không tạo một viên đạn rồi xóa đi viên đạn đó nếu trúng mục tiêu hay đi quá xa, mà mình sẽ
    //tạo sẵn các viên đạn trước rồi khi bắn, ta bật nó lên mà khi trúng thì ta tắt nó đi

    //Cái Script này dùng để quản lý các viên đạn của kẻ địch
    public GameObject enemyBullet;
    public List<GameObject> enemyBullets;
    public float storedBulletAmount;

    void Start()
    {
        GameObject tmp;
        for (int i = 0; i < storedBulletAmount; i++)
        {
            tmp = Instantiate(enemyBullet);
            tmp.SetActive(false);
            enemyBullets.Add(tmp);
        }
    }
    public GameObject fireBullet()
    {
        for (int i = 0; i < storedBulletAmount; i++)
        {
            if (!enemyBullets[i].activeInHierarchy)
            return enemyBullets[i];
        }
        return null;
    }
}
