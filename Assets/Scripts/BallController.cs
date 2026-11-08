using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    private Rigidbody2D rb;
    private Vector2 startingVelocity = new Vector2(5f, 5f);
    public void ResetBall()
    {
        transform.position = Vector3.zero;
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = startingVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy")) 
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocityX, rb.linearVelocityY);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.linearVelocity;
            newVelocity.y = -newVelocity.y;
            rb.linearVelocity = newVelocity;
        }

        if (collision.gameObject.CompareTag("WallEnemy")) 
        {
            gameManager.ScorePlayer();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("WallPlayer")) 
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
    }
}