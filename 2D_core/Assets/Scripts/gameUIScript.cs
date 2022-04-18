using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameUIScript : MonoBehaviour
{
    private int lives1;
    private int lives2;
    public TextMeshProUGUI lifeText1;
    public TextMeshProUGUI lifeText2;
    public GameObject loseObject1;
    public GameObject loseObject2;
    public bool GAMEOVER = false;
    
    void Start()
    {
        lives1 = 3;
        lives2 = 3;
        SetCountText();
        loseObject1.SetActive(false);
        loseObject2.SetActive(false);
    }

    void SetCountText()
    {
        lifeText1.text = "Lives: " + lives1.ToString();
        lifeText2.text = "Lives: " + lives2.ToString();
    }

    public void LoseLife1()
    {
        lives1--;
        lifeText1.text = "Lives: " + lives1.ToString();
        if(lives1 < 1)
        {
            loseObject1.SetActive(true);
            GAMEOVER = true;
        }
    }

    public void LoseLife2()
    {
        lives2--;
        lifeText2.text = "Lives: " + lives2.ToString();
        if (lives2 < 1)
        {
            loseObject2.SetActive(true);
            GAMEOVER = true;
        }
    }
}
