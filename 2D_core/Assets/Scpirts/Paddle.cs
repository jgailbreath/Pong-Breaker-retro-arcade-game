using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 6f;
    protected Rigidbody2D rigidBody;
    protected var orgPos = this.transform.position;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
   
}