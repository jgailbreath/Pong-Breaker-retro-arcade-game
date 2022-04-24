using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public void PlayDatShit(string name)
    {
        FindObjectOfType<AudioManager>().Play(name);
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        Debug.Log("OnCollisionEnter2D");

        if (col.gameObject.CompareTag("Wall"))
        {
            PlayDatShit("Tink");
        }

        if (col.gameObject.CompareTag("Player1"))
        {
            PlayDatShit("Tink2");
        }

        if (col.gameObject.CompareTag("Brick"))
        {
            PlayDatShit("Clap");
        }

        if (col.gameObject.CompareTag("Opponent"))
        {
            PlayDatShit("Tink3");
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
