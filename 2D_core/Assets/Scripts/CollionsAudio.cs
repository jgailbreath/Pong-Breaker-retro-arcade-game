using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollionsAudio : MonoBehaviour
{
    public GameObject ball;

    void OnCollisionEnter(Collision col)
    {
        if( col.collider.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if(col.collider.tag == "P1")
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if (col.collider.tag == "Brick")
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if (col.collider.tag == "P2")
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if (col.collider.tag == "Goal")
        {
            FindObjectOfType<AudioManager>().Play("Crash");
        }

        
    }

}
