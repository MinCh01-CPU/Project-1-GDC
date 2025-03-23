using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
   public float bulletSpeed;
    
    void Update()
    {
        transform.position += Vector3.down * bulletSpeed * Time.deltaTime;

        if (transform.position.y < -8) gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.PLAYER_TAG))
        gameObject.SetActive(false);
    }
}
