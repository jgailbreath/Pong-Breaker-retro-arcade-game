using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collisions_Audio : MonoBehaviour
{
    void OnCollisionEnter2d(Collision2D col)
    {
        if( col.collider.CompareTag("Wall"))
        {
            FindObjectOfType<AudioManager>().Play("Tink4");
        }

        if(col.collider.CompareTag("Player1"))
        {
            FindObjectOfType<AudioManager>().Play("Clap");
        }

        if (col.collider.CompareTag("Brick"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if (col.collider.CompareTag("Opponent"))
        {
            FindObjectOfType<AudioManager>().Play("Clap");
        }

        if (col.collider.CompareTag("WestGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Crash");
            FindObjectOfType<AudioManager>().Play("Electro Heart Beat");
        }

        if (col.collider.CompareTag("EastGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Crash");
            FindObjectOfType<AudioManager>().Play("Electro Heart Beat");
        }

    }

}
