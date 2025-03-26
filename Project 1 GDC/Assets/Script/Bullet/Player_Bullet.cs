using UnityEngine;
public class Player_Bullet : MonoBehaviour
{
    private float bulletSpeed = 5f; // Speed at which the bullet moves

    void Update()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime; // Move the bullet upwards
        // Get the screen boundaries
        Vector3 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        // Check if the bullet has moved off the bottom of the screen
        if (transform.position.y < screenBottomLeft.y || transform.position.y > screenTopRight.y ||
            transform.position.x < screenBottomLeft.x || transform.position.x > screenTopRight.x)
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }
    // va chạm với enemy thì đạn sẽ bị hủy
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.ENEMY_TAG)) // If the bullet collides with an enemy
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // Destroy the bullet when it goes off-screen
    }
}