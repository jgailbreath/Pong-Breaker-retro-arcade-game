using UnityEngine;

public class Player : Paddle
{
    private Vector2 dir;

    private void Update()
    {
        //Keyboard Input to control the direction of the paddle of the player
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
        //Apply force to the paddle to move it
        if (dir.sqrMagnitude != 0)
        {
            rigidBody.AddForce(dir * speed);
            
        }
    }
}
