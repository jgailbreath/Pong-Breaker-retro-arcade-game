using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200f;
    public bool onPaddle;
    public Transform paddle;

    private Rigidbody2D rigidBody;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
            rigidBody.AddForce(Vector2.right * this.speed);
            onPaddle = false;
        }
    }

    private void Start()
    {
        //AddStartingForce();
        onPaddle = true;
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f);

        Vector2 dir = new Vector2(x, y);
        rigidBody.AddForce(dir * this.speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("left") || collision.CompareTag("right"))
        {
            rigidBody.velocity = Vector2.zero;
            onPaddle = true;
        }
    }
}
