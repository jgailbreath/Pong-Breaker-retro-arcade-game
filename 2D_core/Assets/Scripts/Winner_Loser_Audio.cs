using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner_Loser_Audio : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Winner_Loser();   
    }

    public void Winner_Loser()
    {
        if ((gameUIScript.sM == true) && (gameUIScript.l1 <= 0))

        {
            FindObjectOfType<AudioManager>().Play("Defeat");
        }
        
        else if ((gameUIScript.l1 < 1) || (gameUIScript.l2 < 1))
        {
            FindObjectOfType<AudioManager>().Play("Victory");
        }
    }
}
