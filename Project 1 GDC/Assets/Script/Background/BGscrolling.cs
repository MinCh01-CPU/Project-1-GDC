using UnityEngine;
using System.Collections;
// Dùng để cuộn background
public class BGscrolling : MonoBehaviour
{
    private const float scrollSpeed = 0.05f;
    private Material mat;
    private Vector2 offset = Vector2.zero;
    void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Start()
    {
        offset = mat.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        offset.y += scrollSpeed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);
    }
}