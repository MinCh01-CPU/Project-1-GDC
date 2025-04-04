using UnityEngine;
// Quản lý đạn của Địch
public class Enemy_Bullet : MonoBehaviour
{
    public float bulletSpeed; // Tốc độ đạn

    void Update()
    {
        transform.position += Vector3.down * bulletSpeed * Time.deltaTime; // Cập nhật vị trí của Viên đạn khi di chuyển

        // Tính kích thước của Màn hình
        Vector3 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        // Nếu đạn đi ra ngoài màn hình thì sẽ bị hủy
        if (transform.position.y < screenBottomLeft.y || transform.position.y > screenTopRight.y ||
            transform.position.x < screenBottomLeft.x || transform.position.x > screenTopRight.x)
        {
            Destroy(gameObject); // Đạn bị hủy
        }
    }
    // Khi đạn của người địch va chạm với người chơi
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.PLAYER_TAG)) // // Nếu đạn va chạm với Player ( Thông qua TAG )
        {
            Destroy(gameObject); // Đạn bị hủy
        }
    }
}