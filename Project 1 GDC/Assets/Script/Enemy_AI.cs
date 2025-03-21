using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float enemySpeed;
    public float detectDistance;
    public Transform playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {    
        float distance = Vector3.Distance(transform.position, playerPosition.position);
          
        if (distance <= detectDistance)
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, enemySpeed * Time.deltaTime );
        else transform.position += Vector3.down * enemySpeed * Time.deltaTime;
    }
}

