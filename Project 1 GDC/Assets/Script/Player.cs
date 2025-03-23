using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public int playerHealth;
    Vector3 screenBounds;
    Vector3 playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        //Cach di chuyen theo chuot
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        //Recommend di chuyen theo WASD vì di chuyển theo chuột dễ chơi quá
        //playerMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * playerSpeed * Time.deltaTime;
        //transform.Translate(playerMovement);

        //Gioi han di chuyen cua nguoi choi o ria man hinh
        float clamedX = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        float clamedY = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y);
        Vector3 Pos = transform.position;
        Pos.x = clamedX;
        Pos.y = clamedY;
        transform.position = Pos;

        if (playerHealth <= 0)
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("da va cham");
        if (collision.CompareTag("Enemy Bullet"))
        playerHealth -= 1;
    }
}
