using UnityEngine;

public class Computer : Paddle
{
    public Rigidbody2D ball;
    private var orgPos = rigidBody.transform.position;


    private void FixedUpdate()
    {
        if (this.ball.velocity.x > 0f)
        {
            if (this.ball.position.y > this.transform.position.y)
            {
                rigidBody.AddForce(Vector2.up * this.speed);
            }
            else if (this.ball.position.y < this.transform.position.y)
            {
                rigidBody.AddForce(Vector2.down * this.speed);
            }
        }
        else
        {
            if (this.transform.position.y > 0f)
            {
                rigidBody.AddForce(Vector2.down * this.speed);
            }
            else if (this.transform.position.y < 0f)
            {
                rigidBody.AddForce(Vector2.up * this.speed);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            rigidBody.constraints = RigidbodyConstraints2D.None;
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            rigidBody.transform.position = orgPos;
        }
    }
}
