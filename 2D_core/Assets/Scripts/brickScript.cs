using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states;
    public int health { get; private set; }

    public void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        this.health = this.states.Length;
        this.spriteRenderer.sprite = this.states[this.health - 1];
    }

    private void Hit()
    {
        this.health--;

        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.spriteRenderer.sprite = this.states[this.health - 1];
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Hit();
        }
    }
}
