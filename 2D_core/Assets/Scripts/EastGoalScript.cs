using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EastGoalScript : MonoBehaviour
{
    public gameUIScript UI;

    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            UI.LoseLife2();
        }
    }
}
