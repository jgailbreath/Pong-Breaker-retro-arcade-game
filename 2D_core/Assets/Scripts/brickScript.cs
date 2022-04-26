using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; } // Allows to access sprites
    public Sprite[] states; // Array to hold sprites for different brick states
    public int health { get; private set; } // Holds current brick state

    public void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>(); // Initializing sprite renderer
    }

    private void Start()
    {
        this.health = this.states.Length; // Current health of brick
        this.spriteRenderer.sprite = this.states[this.health - 1]; // Initializing sprite state
    }

    // Triggers when a brick is hit
    private void Hit()
    {
        this.health--; // Decrement health

        // If brick has 0 health, destroy brick.
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
        else // Iterate to next visible brick state
        {
            this.spriteRenderer.sprite = this.states[this.health - 1];
        }
    }

    // Determines collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If brick detects a collision from the ball, call the Hit function
        if(collision.gameObject.tag == "Ball")
        {
            Hit();
        }
    }
}
