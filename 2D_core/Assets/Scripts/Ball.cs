using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 20f;
    public Transform paddle;
    public float timeVal = 5f;
    public gameUIScript UI;
    private bool onPaddle;
    private Rigidbody2D rigidBody;
    private Vector2 dir;
    private bool countDown = true;
    private float orgTimeVal;
    public bool reset = false;
    

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        orgTimeVal = timeVal;
        if (paddle.parent.CompareTag("Player1"))
        {
            dir = Vector2.right;
        }
        else if (paddle.parent.CompareTag("Opponent"))
        {
            dir = Vector2.left;
        }
    }

    public void Reset()
    {
        rigidBody.velocity = Vector2.zero;
        onPaddle = true;
        countDown = true;
        timeVal = 5f;
        reset = false;
    }

    private void Update()
    {
        if (onPaddle)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && onPaddle)
        {
            rigidBody.AddForce(dir * this.speed);
            onPaddle = false;
            timeVal = 0f;
        }

        if (timeVal >= 0 && countDown)
        {
            timeVal -= Time.deltaTime;
        }
        else if (onPaddle)
        {
            rigidBody.AddForce(dir * this.speed);
            onPaddle = false;
            countDown = false;
            timeVal = orgTimeVal;
        }
    }

    private void Start()
    {
        onPaddle = true;
    }

    
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
        else if (collision.CompareTag("Player1"))
        {
            rigidBody.AddForce(Vector2.right * this.speed);
        }
        else if (collision.CompareTag("Opponent"))
        {
            rigidBody.AddForce(Vector2.left * this.speed);
        }

        if (collision.CompareTag("Wall"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if (collision.CompareTag("Brick"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

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
