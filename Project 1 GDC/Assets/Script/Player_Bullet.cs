using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    
    void Update()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;

        if (transform.position.y > 8) gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.ENEMY_TAG))
        gameObject.SetActive(false);
    }
}
