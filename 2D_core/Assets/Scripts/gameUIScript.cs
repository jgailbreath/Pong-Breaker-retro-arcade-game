using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameUIScript : MonoBehaviour
{
    private int lives;
    public TextMeshProUGUI lifeText;
    public GameObject loseTextObject;
    
    void Start()
    {
        lives = 3;
        SetCountText();
        loseTextObject.SetActive(false);
    }

    void SetCountText()
    {
        lifeText.text = "Lives: " + lives.ToString();
    }

    void LoseLife()
    {
        lives--;
        lifeText.text = "Lives: " + lives.ToString();
        if(lives < 1)
        {
            loseTextObject.SetActive(true);
        }
    }
}
