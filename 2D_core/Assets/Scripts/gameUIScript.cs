using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameUIScript : MonoBehaviour
{
    private int lives1;
    private int lives2;
    public TextMeshProUGUI lifeText1;
    public TextMeshProUGUI lifeText2;
    public TextMeshProUGUI time;
    public GameObject loseObject1;
    public GameObject loseObject2;
    public GameObject mainMenuButton;
    public GameObject playAgainButton;
    public Button pauseButton;
    public Ball ball;
    private float timer;
    private bool singleMode = false;
    static public int l1;
    static public int l2;
    static public bool sM = false;




    void Start()
    {
        Time.timeScale = 1;
        lives1 = 3;
        lives2 = 3;
        l1 = lives1;
        l2 = lives2;
        SetCountText();
        loseObject1.SetActive(false);
        loseObject2.SetActive(false);
        mainMenuButton.SetActive(false);
        playAgainButton.SetActive(false);
        timer = ball.timeVal + 1;
    }

    private void Update()
    {
        if (lives1 < 1)
        {
            StartCoroutine(Delay());
        }

        if (GameObject.FindGameObjectWithTag("Brick") == null)
        {
            FindObjectOfType<AudioManager>().Play("Victory");
            StartCoroutine(Delay());
        }

        l1 = lives1;
        l2 = lives2;
        sM = singleMode;

        if ((lives1 >= 1 && lives2 >= 1) && timer >= 1)
        {
            timer = (int)ball.timeVal + 1;
            time.text = timer.ToString();
        }
        else
        {
            time.text = "";
        }


        if (time.text == "6")
        {
            time.text = "";
        }

        if (Time.timeScale == 0)
        {
            mainMenuButton.SetActive(true);
            playAgainButton.SetActive(true);
        }
        else
        {
            mainMenuButton.SetActive(false);
            playAgainButton.SetActive(false);
        }


        if (singleMode)
        {
            if(lives1 < 1)
            {
                FindObjectOfType<AudioManager>().Play("Defeat");
                StartCoroutine(Delay());
            }

            if (GameObject.FindGameObjectWithTag("Brick") == null)
            {
                FindObjectOfType<AudioManager>().Play("Victory");
                StartCoroutine(Delay());
                
                loseObject2.SetActive(true);
                time.text = "";
                pauseButton.onClick.Invoke();
                Time.timeScale = 0;
            }
        }
    }

    void SetCountText()
    {
        lifeText1.text = "Lives: " + lives1.ToString();
        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            lifeText2.text = "Lives: " + lives2.ToString();
        }
        else if (SceneManager.GetActiveScene().name == "Scene1" || SceneManager.GetActiveScene().name == "SinglePlayerDemo")
        {
            lifeText2.text = "";
            singleMode = true;
        }
    }

    public void LoseLife1()
    {
        lives1--;
        l1 = lives1;
        lifeText1.text = "Lives: " + lives1.ToString();
        if(lives1 < 1)
        {
            

            loseObject1.SetActive(true);
            time.text = "";
            pauseButton.onClick.Invoke();
        }
    }

    public void LoseLife2()
    {
        lives2--;
        l2 = lives2;
        lifeText2.text = "Lives: " + lives2.ToString();
        if (lives2 < 1)
        {
            loseObject2.SetActive(true);
            time.text = "";
            pauseButton.onClick.Invoke();
        }
    }

    IEnumerator Delay()
    {
    
        FindObjectOfType<AudioManager>().Play("Defeat");
        yield return new WaitForSeconds(6);
    }
    
}
