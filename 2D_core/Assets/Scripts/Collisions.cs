using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public void PlayAudio(string name)
    {
        FindObjectOfType<AudioManager>().Play(name);
    }

    //  Play selected audio clips from sounds array when collisions on ball are detected
    //  --specific object collisions identified by tags on game objects
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("SouthWall") || col.gameObject.CompareTag("NorthWall"))
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

    //  Play selected audio clips from sounds array when goal objects are triggered
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WestGoal"))
        {
            PlayAudio("Crash");
        }
        else if (collision.gameObject.CompareTag("EastGoal"))
        {
            PlayAudio("Horror");

        }
    }
}
