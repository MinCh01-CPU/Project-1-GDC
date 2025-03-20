using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Gun : MonoBehaviour
{

    public float shootCoolDown, shootRate;

    public GameObject doubleBullet;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       shootCoolDown -= Time.deltaTime;
       
       if (Input.GetMouseButton(0) && shootCoolDown <= 0)
       Shoot();

    }
    void Shoot()
    {
       //thay được bằng Object pooling thì sẽ tốt hơn

       Instantiate(doubleBullet, transform.position, transform.rotation);
       shootCoolDown = shootRate;
    }
}
