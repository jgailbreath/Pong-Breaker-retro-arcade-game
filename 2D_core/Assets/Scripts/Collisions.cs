using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public void PlayAudio(string name)
    {
        FindObjectOfType<AudioManager>().Play(name);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            PlayAudio("Tink");
        }

        if (col.gameObject.CompareTag("Player1"))
        {
            PlayAudio("Tink2");
        }

        if (col.gameObject.CompareTag("Brick"))
        {
            PlayAudio("Clap");
        }

        if (col.gameObject.CompareTag("Opponent"))
        {
            PlayAudio("Tink3");
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WestGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Crash"); // trigger to call audio clip
        }
        else if (collision.gameObject.CompareTag("EastGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Horror"); // trigger to call audio clip
        }
    }
}
