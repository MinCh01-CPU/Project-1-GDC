using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    //Script này dùng điền khiển hành vi của Enemy và máu của nó
    
    public float enemySpeed, enemyChasingSpeed; //tốc độ địch và tốc độ của địch khi địch truy đuổi người chơi
    float distance; //Tính khoảng cách giữa địch và người chơi
    public float detectDistance; //khoảng cách mà địch sẽ phát hiện người chơi và đuổi theo

    public int enemyHealth; //máu của kẻ địch (để int)
    Transform playerPosition; //biến chứa vị trí của người chơi
    void Start()
    {
        playerPosition = Game_Manager.Instance.Player.transform; //lấy vị trí của người chơi đã được lưu trong Game Manager,
                                                                 //về lý do không lấy trực tiếp từ Player luôn mà phải thông qua
                                                                 //Game Manager làm trung gian vì nếu Player chết (em SetActive(false) cho Player)
                                                                 //thì sẽ sinh ra lỗi do Enemy ko đọc được vị trí của người chơi;
    }

    void Update()
    {    
        distance = Vector3.Distance(transform.position, playerPosition.position); //Tính khoảng cách từ người chơi tới địch
          
        if (DetectPlayer() && Game_Manager.Instance.playerIsAlive() ) //nếu phát hiện người chơi và người chơi còn sống
        {                
            transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, enemyChasingSpeed * Time.deltaTime );
            //Enemy sẽ đuổi theo Player
        }
        else transform.position += Vector3.down * enemySpeed * Time.deltaTime;
        //nếu không phát hiện thì nó sẽ cứ đi thẳng

        if (enemyHealth <= 0)  //Khúc này là máu của Enemy
        Destroy(gameObject);   //hết máu thì Destroy nó luôn
    }
    bool DetectPlayer()
   {
    if (distance <= detectDistance && transform.position.y >= playerPosition.position.y)
    //nếu khoảng cách giữa Player và Enemy nhỏ hơn khoảng cách phát hiện (tức vào tầm ngắm) và Player phải ở trước mặt Enemy
    return true;
    return false;
   }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.PLAYER_BULLET_TAG)) //Nếu Enemy va chạm với đạn của người chơi thì bị trừ 1 máu
        enemyHealth -= 1;
    }

}

