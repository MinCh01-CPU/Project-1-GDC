using UnityEngine;

public class BG : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Screen.width / Screen.height;
        transform.localScale = new Vector3(width, height, 0f);
    }
}
