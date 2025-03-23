using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Gun : MonoBehaviour
{

    public float shootCoolDown, shootRate;

    public GameObject doubleBullet;
    public PBulletManager pBulletManager;

    void Awake()
    {
        pBulletManager = GameObject.Find("Player_Bullet_Pool").GetComponent<PBulletManager>();
    }
    void Update()
    {  
      if (Input.GetKey(KeyCode.Space) && shootCoolDown <= 0)
      Shoot();
      
      shootCoolDown -= Time.deltaTime;

    }
    void Shoot()
    { 
      doubleBullet = pBulletManager.fireBullet();
      doubleBullet.transform.position = transform.position;
      doubleBullet.transform.rotation = transform.rotation;
      doubleBullet.SetActive(true);

      shootCoolDown = shootRate;
    }
    
}
