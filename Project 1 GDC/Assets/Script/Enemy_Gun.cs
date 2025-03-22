using UnityEngine;

public class Enemy_Gun : MonoBehaviour
{
    public GameObject singleBullet;

    public float shootCoolDown, shootRate;

    void Update()
    {
        if (shootCoolDown <=0)
        Shoot();

        shootCoolDown -= Time.deltaTime;
    }
    public void Shoot()
    {
        singleBullet = EBulletManager.eBulletManager.fireBullet();
        singleBullet.transform.position = transform.position;
        singleBullet.transform.rotation = transform.rotation;
        singleBullet.SetActive(true);

        shootCoolDown = shootRate;
    }
}
