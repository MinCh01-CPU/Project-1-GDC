using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    // Start is called once before the first execution of Update after the MonoBeha
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;

        if (transform.position.y >= 11) Destroy(gameObject);
    }
}
