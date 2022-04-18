using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 6f;
    protected Rigidbody2D rigidBody;
    protected Vector3 orgPos;
    public gameUIScript UI;
       

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (UI.GAMEOVER)
        {
            rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
            rigidBody.velocity = Vector2.zero;
        }

            

    }
}