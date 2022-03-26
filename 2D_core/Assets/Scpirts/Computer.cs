using UnityEngine;

public class Computer : Paddle
{
    public Rigidbody2D ball;


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
}
