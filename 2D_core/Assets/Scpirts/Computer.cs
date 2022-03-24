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
                rigidBody.velocity = (Vector2.up * this.speed);
            }
            else if (this.ball.position.y < this.transform.position.y)
            {
                rigidBody.velocity = (Vector2.down * this.speed);
            }
        }
        else
        {
            if (this.transform.position.y > 0f)
            {
                rigidBody.velocity = (Vector2.down * this.speed);
            }
            else if (this.transform.position.y < 0f)
            {
                rigidBody.velocity = (Vector2.up * this.speed);
            }
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.tag == "Ball")
    //    {
    //        Vector3 tempVect = new Vector3(collision.rigidbody.velocity.x * -1, collision.rigidbody.velocity.y * -1, collision.rigidbody.velocity.z);
    //        collision.rigidbody.velocity = tempVect;
    //    }
    //}
}
