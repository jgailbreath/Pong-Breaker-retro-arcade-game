using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBricks : MonoBehaviour
{
    private void Update()
    {
        No_Bricks();
    }
    public void No_Bricks()
    {
        if ((GameObject.FindGameObjectWithTag("Brick") == null))// && (gameUIScript.l1 > 0 && gameUIScript.l2 > 0))
        {
            FindObjectOfType<AudioManager>().Play("Cowbell");

            FindObjectOfType<AudioManager>().Play("Karate Yell");
        }
    }
}
