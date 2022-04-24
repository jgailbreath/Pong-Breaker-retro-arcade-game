using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    void PlayDatShit(string name)
    {
        FindObjectOfType<AudioManager>().Play(name);
    }

    string choice;
    

void OnCollisionEnter2d(Collision2D col)
    {
        
        if( col.gameObject.CompareTag("Wall"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if(col.gameObject.CompareTag("Player1"))
        {
            PlayDatShit("Tink2");
        }

        if (col.gameObject.CompareTag("Brick"))
        {
            PlayDatShit("Clap");
        }

        if (col.collider.CompareTag("Opponent"))
        {
            PlayDatShit("Tink3");
        }

        if (col.gameObject.CompareTag("WestGoal"))
        {
            PlayDatShit("Horror");
        }

        if (col.collider.CompareTag("EastGoal"))
        {
            PlayDatShit("Crash");
        }

    }

}
