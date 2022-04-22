using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collisions_Audio : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if( col.collider.CompareTag("Wall"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if(col.collider.CompareTag("P1"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if (col.collider.CompareTag("Brick"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if (col.collider.CompareTag("P2"))
        {
            FindObjectOfType<AudioManager>().Play("Tink");
        }

        if (col.collider.CompareTag("WestGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Crash");
        }

        if (col.collider.CompareTag("EastGoal"))
        {
            FindObjectOfType<AudioManager>().Play("Crash");
        }

    }

}
