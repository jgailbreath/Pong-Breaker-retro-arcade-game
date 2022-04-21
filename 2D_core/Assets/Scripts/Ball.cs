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
    
    /*
    --jg --4-21--somehow things took a left here and i have no clue why/how
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WestGoal"))
        {
            UI.LoseLife1();
            reset = true;
            // jg----playing with the audio setup
            FindObjectOfType<AudioManager>().Play("Electro Heart Beat");
            FindObjectOfType<AudioManager>().Play("Crash");
        }
        else if (collision.CompareTag("EastGoal"))
        {
            UI.LoseLife2();
            reset = true;
            //jg---playing with the audio setup
            FindObjectOfType<AudioManager>().Play("Electro Heart Beat");
            FindObjectOfType<AudioManager>().Play("Crash");
        }
//  4-21--jg--something weird happened here, not sure what<<<<<<< J.-Gailbreath
        else if (collision.CompareTag("Player1"))
        {
            rigidBody.AddForce(Vector2.right * this.speed):
            FindObjectofType<AudioManager>().Play("Clap");
        }
*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
// 4-21 jg>>>>>>> main
        {
            if (velY <= 0)
            {
                rigidBody.AddForce(Vector2.down * this.speed)
            }
        }
        else if (collision.gameObject.CompareTag("SouthWall"))
        {
            if (velY <= 0)
            {
                rigidBody.AddForce(Vector2.up * this.speed)
            }
        }

        if (collision.CompareTag("Player1") || collision.CompareTag("Opponent"))
        {
            FindObjectOfType<AudioManager>().Play("Clap");
        }
        
        if (collision.CompareTag("Wall") ||  collision.CompareTag("Brick"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }
        
        if (collision.CompareTag("EastGoal") || collision.CompareTag("WestGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Electro Heart Beat");
            FindObjectOfType<AudioManager>().Play("Crash");
        }


    /*  jg---trying out different setups for the audio manager
    void OnCollisionEnter(Collision col)
    {
        //if (col.collider.tag == "Wall")
        if (col.CompareTag("Wall"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        //if (col.collider.tag == "Player1")
        C
        //if (col.collider.tag == "Brick")
        if (col.CompareTag("Brick"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        //if (col.collider.tag == "opponent")
        if (col.CompareTag("opponent"))
        {
            FindObjectOfType<AudioManager>().Play("Clap");
        }

        //if (col.collider.tag == "WestGoal")
        if (col.CompareTag("WestGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Crash");
        }

        //if (col.collider.tag == "EastGoal")
        if (col.CompareTag("EastGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Crash");
        }


    }
    */
}
