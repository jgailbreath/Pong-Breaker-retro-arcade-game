using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollionsAudio : MonoBehaviour
{
    public GameObject Ball;

    void OnCollisionEnter(Collision col)
    {
        if( col.collider.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if(col.collider.tag == "Player1")
        {
            FindObjectOfType<AudioManager>().Play("Clap");
        }

        if (col.collider.tag == "Brick")
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if (col.collider.tag == "opponent")
        {
            FindObjectOfType<AudioManager>().Play("Clap");
        }

        if (col.collider.tag == "WestGoal")
        {
            FindObjectOfType<AudioManager>().Play("Crash");
        }

        if (col.collider.tag == "EastGoal")
        {
            FindObjectOfType<AudioManager>().Play("Crash");
        }

        
    }

}
