using UnityEngine;

public class Player : Paddle
{
    private Vector2 dir;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir = Vector2.down;
        }
        else
        {
            dir = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (dir.sqrMagnitude != 0)
        {
            rigidBody.velocity = dir * speed;
            
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
