using System.Collections.Generic;
using UnityEngine;

public class PBulletManager : MonoBehaviour
{
    public static PBulletManager pBulletManager;
    public GameObject playerBullet;
    public List<GameObject> playerBullets;
    public float storedBulletAmount;
    void Awake()
    {
        pBulletManager = this;
    }

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
