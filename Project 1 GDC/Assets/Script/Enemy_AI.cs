using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float enemySpeed, enemyChasingSpeed;
    float distance;
    public float detectDistance;
    public int enemyHealth;
    
    private Vector3 movementPoint;
    Transform playerPosition;
    void Start()
    {
        playerPosition = Game_Manager.Instance.Player.transform;
    }

    void Update()
    {    
        distance = Vector3.Distance(transform.position, playerPosition.position);
        movementPoint = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);
          
        if (DetectPlayer() && Game_Manager.Instance.playerIsAlive() )
        {
            transform.position = Vector3.MoveTowards(transform.position, movementPoint, enemyChasingSpeed * Time.deltaTime );
        }
        else transform.position += Vector3.down * enemySpeed * Time.deltaTime;

        if (enemyHealth <= 0)
        gameObject.SetActive(false);
    }
    bool DetectPlayer()
   {
    if (distance <= detectDistance && transform.position.y >= playerPosition.position.y)
    return true;
    return false;
   }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.PLAYER_BULLET_TAG))
        enemyHealth -= 1;
    }

}

