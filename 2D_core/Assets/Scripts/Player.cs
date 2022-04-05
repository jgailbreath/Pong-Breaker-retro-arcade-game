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
            rigidBody.AddForce(dir * speed);
            
        }
    }
}
