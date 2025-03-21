using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 screenBounds;
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


        //Gioi han di chuyen cua nguoi choi o ria man hinh
        float clamedX = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
        float clamedY = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y);
        Vector3 Pos = transform.position;
        Pos.x = clamedX;
        Pos.y = clamedY;
        transform.position = Pos;

    }
}
