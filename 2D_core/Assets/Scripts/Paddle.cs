using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 6f;
    protected Rigidbody2D rigidBody;
    protected Vector3 orgPos;
       

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            rigidBody.velocity = Vector2.zero;
        }

            

    }
}