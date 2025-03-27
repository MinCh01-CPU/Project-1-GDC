using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private float playerSpeed = 5f; // Tốc độ di chuyển của người chơi
    Vector3 screenBounds;
    Vector3 playerMovement;
    private Rigidbody2D rb;
    [SerializeField] private GameObject bullet;
    private bool canShoot = true; // Flag to control shooting
    private float shootCooldown = 0.2f; // Cooldown time between shots

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        Di_chuyen();
        Ban();
    }

    // Bắn đạn
    void Ban()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Space)) // Check for space key or left mouse button
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            // Đạn ko xoay
            canShoot = false; // Set canShoot to false to prevent continuous shooting
            StartCoroutine(ShootCooldown()); // Start cooldown coroutine
        }
        else if (canShoot && (!Input.GetKeyDown(KeyCode.Space)) && Input.GetMouseButtonDown(0)) // Check for space key or left mouse button
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            // Đạn ko xoay
            canShoot = false; // Set canShoot to false to prevent continuous shooting
            StartCoroutine(ShootCooldown()); // Start cooldown coroutine
        }
    }
    // Delay bullet
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCooldown); // Wait for the cooldown time
        canShoot = true; // Allow shooting again
    }

    void Di_chuyen()
    {
        //Recommend di chuyen theo WASD vì di chuyển theo chuột dễ chơi quá
        playerMovement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * playerSpeed * Time.deltaTime;
        transform.Translate(playerMovement);

        //Giới bạn di chuyển của người chơi ko đi qua rìa màn hình
        float clamedX = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        float clamedY = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y);
        Vector3 Pos = transform.position;
        Pos.x = clamedX;
        Pos.y = clamedY;
        transform.position = Pos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.Enemy_BULLET_TAG) || collision.CompareTag(Constant.ENEMY_TAG))
        {
            gameObject.SetActive(false); // Vô hiệu hóa Player
            if (Game_Manager.Instance != null)
            {
                Game_Manager.Instance.TriggerGameOver();
            }
            else
            {
                Debug.LogError("GameManager instance is null! Ensure Game_Manager exists in the Scene.");
            }

            gameObject.SetActive(false); // Vô hiệu hóa Player
        }
    }
}