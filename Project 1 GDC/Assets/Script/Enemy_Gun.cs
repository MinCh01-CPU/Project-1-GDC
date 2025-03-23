using UnityEngine;

public class Enemy_Gun : MonoBehaviour
{
    public EBulletManager eBulletManager;
    GameObject singleBullet;

    public float shootRate;
    float shootCoolDown;

    void Awake()
    {
        eBulletManager = GameObject.Find("Enemy_Bullet_Pool").GetComponent<EBulletManager>();
        //lấy Component (cái script EBulletManager được gắn trong cái gameObject tên "Enemy_Bullet_Pool" có sẵn trên scene)
    }
    void Update()
    {
        if (shootCoolDown <=0)
        Shoot();

        shootCoolDown -= Time.deltaTime;
    }
    public void Shoot()
    {
        singleBullet = eBulletManager.fireBullet(); //hàm fireBullet() trong cái script EBulletManager nó sẽ trả về cái Bullet đang tắt
        singleBullet.transform.position = transform.position; //gán thông số vị trí của Gun và Bullet
        singleBullet.transform.rotation = transform.rotation;
        singleBullet.SetActive(true); //Bật các Bullet lên

        shootCoolDown = shootRate;
    }
}
