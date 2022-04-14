using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 20f;
    public Transform paddle;
    public float timeVal = 5f;
    private bool onPaddle;
    private Rigidbody2D rigidBody;
    private Vector2 dir;
    private bool countDown = true;
    private float orgTimeVal;

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

    private void Update()
    {
        if (onPaddle)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && onPaddle)
        {
            //AddStartingForce();
            rigidBody.AddForce(dir * this.speed);
            onPaddle = false;
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
        if (collision.CompareTag("WestGoal") || collision.CompareTag("EastGoal"))
        {
            rigidBody.velocity = Vector2.zero;
            onPaddle = true;
            countDown = true;
        }
        else if (collision.CompareTag("Player"))
        {
            rigidBody.AddForce(Vector2.right * this.speed);
        }
        else if (collision.CompareTag("Opponent"))
        {
            rigidBody.AddForce(Vector2.left * this.speed);
        }
    }
}
