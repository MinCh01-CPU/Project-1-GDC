using UnityEngine;

public class Enemy2_Bullet : MonoBehaviour
{
    public float bulletSpeed; // Speed at which the bullet moves

    void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        Time.timeScale = 1f;
        transform.position += Vector3.down * bulletSpeed * Time.deltaTime; // Move the bullet downwards

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.PLAYER_TAG)) // If the bullet collides with the player
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }
}