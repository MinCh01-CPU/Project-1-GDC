using UnityEngine;
using System.Collections.Generic;

public class EBulletManager : MonoBehaviour
{
    public static EBulletManager eBulletManager;
    public GameObject enemyBullet;
    public List<GameObject> enemyBullets;
    public float storedBulletAmount;
    void Awake()
    {
        eBulletManager = this;
    }

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
