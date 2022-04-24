using UnityEngine;

public class Ball : MonoBehaviour
{
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
        rigidBody = GetComponent<Rigidbody2D>();
        orgTimeVal = timeVal;
        if (paddle.parent.CompareTag("Player1"))
        {
            startVelocity = new Vector2(speed, 0f);
        }
        else if (paddle.parent.CompareTag("Player2"))
        {
            startVelocity = new Vector2(-1 * speed, 0f);
        }
    }

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
        if (onPaddle)
        {
            transform.position = paddle.position;
        }

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
        if (collision.CompareTag("WestGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Crash");
            UI.LoseLife1();
            reset = true;
        }
        else if (collision.CompareTag("EastGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Horror");
            UI.LoseLife2();
            reset = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float velY = rigidBody.velocity.y;
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Opponent"))
        {
            rigidBody.velocity = new Vector2(-1 * this.speed,velY);
        }
        else if (collision.gameObject.CompareTag("Player1"))
        {
            //FindObjectOfType<AudioManager>().Play("Clap");
            rigidBody.velocity = new Vector2(this.speed, velY);
        }
        else if (collision.gameObject.CompareTag("NorthWall"))
        {
            //FindObjectOfType<AudioManager>().Play("Tink");
            if (velY <= 0)
            {
                rigidBody.AddForce(Vector2.down * this.speed);
            }
        }
        else if (collision.gameObject.CompareTag("SouthWall"))
        {
            //FindObjectOfType<AudioManager>().Play("Tink");
            if (velY <= 0)
            {
                rigidBody.AddForce(Vector2.up * this.speed);
            }
        }
    }
}
