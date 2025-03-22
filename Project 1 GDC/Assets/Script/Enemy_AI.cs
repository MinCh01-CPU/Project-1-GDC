using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public static Enemy_AI enemy_AI;
    public float enemySpeed, enemyChasingSpeed;
    public float distance;
    public float detectDistance;
    
    private Vector3 movementPoint;
    public Transform playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {    
        distance = Vector3.Distance(transform.position, playerPosition.position);
        movementPoint = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);
          
        if (DetectPlayer())
        {
            transform.position = Vector3.MoveTowards(transform.position, movementPoint, enemyChasingSpeed * Time.deltaTime );
        }
        else transform.position += Vector3.down * enemySpeed * Time.deltaTime;
    }
   public bool DetectPlayer()
   {
    if (distance <= detectDistance && transform.position.y >= playerPosition.position.y)
    return true;
    return false;
   }

}

