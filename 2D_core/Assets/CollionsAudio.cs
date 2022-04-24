using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollionsAudio : MonoBehaviour
{
    public GameObject ball;

    void OnCollisionEnter2D(Collision2D col)
    {
        if( col.collider.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if(col.collider.tag == "Player1")
        {
            FindObjectOfType<AudioManager>().Play("Clap");
        }

        if (col.collider.CompareTag("Brick"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if (col.collider.tag == "Opponent")
        {
            FindObjectOfType<AudioManager>().Play("Clap");
        }

        if (col.collider.tag == "Goal")
        {
            FindObjectOfType<AudioManager>().Play("Crash");
        }

        
    }

}
