using UnityEngine;

public class Ball : MonoBehaviour
{
    // Establish variables to be used in class.
    public float speed = 6f;
    public Transform paddle;
    public float timeVal = 5f;
    public gameUIScript UI;
    private bool onPaddle;
    private Rigidbody2D rigidBody;
    private Vector2 startVelocity;
    private bool countDown = true;
    private float orgTimeVal;
    public bool reset = false;


    private void Start()
    {
        onPaddle = true;
    }
    
    private void Awake()
    {
        //Set the velocity of the ball depending on which player it is on
        rigidBody = GetComponent<Rigidbody2D>();
        orgTimeVal = timeVal;//The timer to release the game
        if (paddle.parent.CompareTag("Player1"))
        {
            startVelocity = new Vector2(speed, 0f);
        }
        else if (paddle.parent.CompareTag("Player2"))
        {
            startVelocity = new Vector2(-1 * speed, 0f);
        }
    }

    //Reset the ball back to the paddle and make the ball have no velocity 
    public void Reset()
    {
        rigidBody.velocity = Vector2.zero;
        onPaddle = true;
        countDown = true;
        timeVal = orgTimeVal;
        reset = false;
    }

    private void Update()
    {
        //Keep the ball on the paddle
        if (onPaddle)
        {
            transform.position = paddle.position;
        }

        //Release the ball when the timer is 0
        if (timeVal >= 0 && countDown)
        {
            timeVal -= Time.deltaTime;
        }
        else if (onPaddle)
        {
            rigidBody.velocity = startVelocity;
            onPaddle = false;
            countDown = false;
            timeVal = orgTimeVal;
        }

        //Push the ball away from the north and south walls when it gets stuck
        if ((rigidBody.velocity.x > -1 * speed) && (rigidBody.velocity.x <= 0f))
        {
            rigidBody.velocity = new Vector2(-1 * speed,rigidBody.velocity.y);
        }
        else if ((rigidBody.velocity.x < speed) && (rigidBody.velocity.x >= 0f))
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Goal interaction
        if (collision.CompareTag("WestGoal"))
        {
            UI.LoseLife1();
            reset = true;
        }
        else if (collision.CompareTag("EastGoal"))
        {
            UI.LoseLife2();
            reset = true;
        }
        
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Velocity control for ball
        float velY = rigidBody.velocity.y;
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Opponent"))
        {
            rigidBody.velocity = new Vector2(-1 * this.speed,velY);
        }
        else if (collision.gameObject.CompareTag("Player1"))
        {
            rigidBody.velocity = new Vector2(this.speed, velY);
        }
        else if (collision.gameObject.CompareTag("NorthWall"))
        {
            if (velY <= 0)
            {
                rigidBody.AddForce(Vector2.down * this.speed);
            }
        }
        else if (collision.gameObject.CompareTag("SouthWall"))
        {
            if (velY <= 0)
            {
                rigidBody.AddForce(Vector2.up * this.speed);
            }
        }
    }
}
