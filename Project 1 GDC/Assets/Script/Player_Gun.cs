using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Gun : MonoBehaviour
{

    public float shootCoolDown, shootRate;

    public GameObject doubleBullet;
    
    void Update()
    {  
      if (Input.GetMouseButton(0) && shootCoolDown <= 0)
      Shoot();
      
      shootCoolDown -= Time.deltaTime;

    }
    void Shoot()
    { 
      doubleBullet = PBulletManager.pBulletManager.fireBullet();
      doubleBullet.transform.position = transform.position;
      doubleBullet.transform.rotation = transform.rotation;
      doubleBullet.SetActive(true);

      shootCoolDown = shootRate;
    }
    
}
