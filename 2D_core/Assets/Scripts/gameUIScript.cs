using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameUIScript : MonoBehaviour
{
    private int lives1; // Lives for player 1
    private int lives2; // Lives for player 2
    public TextMeshProUGUI lifeText1; // Display for player 1 lives
    public TextMeshProUGUI lifeText2; // Display for player 2 lives
    public TextMeshProUGUI time; // Display for timer
    public GameObject loseObject1; // Displays when player 1 wins
    public GameObject loseObject2; // Displays when player 2 wins
    public GameObject mainMenuButton; // Button to take user back to main menu
    public GameObject playAgainButton; // Button to play level again
    public Button pauseButton; // Button to pause game
    public Ball ball; // Takes timer from ball script
    private float timer; // Variable to hold amount of time left before ball launch
    private bool singleMode = false; // Checks what game mode user is in
    private bool noBricks = false; // Checks if any bricks remain



    void Start()
    {
        Time.timeScale = 1; // Make sure game is not paused
        loseObject1.SetActive(false);     //
        loseObject2.SetActive(false);     // Set game objects and buttons to not appear prematurely
        mainMenuButton.SetActive(false);  //
        playAgainButton.SetActive(false); // 
        lives1 = 3; // Initialize player 1 and two lives
        lives2 = 3;
        SetCountText(); // Initialize text boxes
        timer = ball.timeVal + 1; // Initialize timer value
    }

    private void Update()
    {
        // If both players are alive and timer is running, display timer
        if ((lives1 >= 1 && lives2 >= 1) && timer >= 1)
        {
            timer = (int)ball.timeVal + 1;
            time.text = timer.ToString();
        }
        else // Remove timer
        {
            time.text = "";
        }

        // Do not display out of range number
        if (time.text == "6")
        {
            time.text = "";
        }

        // If game is paused, display menu buttons
        if (Time.timeScale == 0)
        {
            mainMenuButton.SetActive(true);
            playAgainButton.SetActive(true);
        }
        else // Hide menu buttons when game is not paused
        {
            mainMenuButton.SetActive(false);
            playAgainButton.SetActive(false);
        }

        // Check if single player mode is over
        if (singleMode)
        {
            if (!noBricks && GameObject.FindGameObjectWithTag("Brick") == null)
            {
                noBricks = true;
                BrickChecker();
            }
        }
    }

    //Initialize player lives textbox
    void SetCountText()
    {
        lifeText1.text = "Lives: " + lives1.ToString();
        if (SceneManager.GetActiveScene().name == "Scene2") // Check if user is in 2 player mode
        {
            lifeText2.text = "Lives: " + lives2.ToString();
            FindObjectOfType<AudioManager>().Play("Background_2"); // Play background music for level 2
        }
        else if (SceneManager.GetActiveScene().name == "Scene1" || SceneManager.GetActiveScene().name == "SinglePlayerDemo") // Check if user is in 1 player mode
        {
            lifeText2.text = "";
            singleMode = true;
            FindObjectOfType<AudioManager>().Play("Background_3"); // Play background music for level 1
        }
    }

    // Checks if single player is over (victory condition)
    void BrickChecker()
    {
        loseObject2.SetActive(true);
        time.text = "";
        pauseButton.onClick.Invoke();
        FindObjectOfType<AudioManager>().Stop("Background_3");
        FindObjectOfType<AudioManager>().Play("Victory");
    }

    // Removes life from player 1 if a ball hits their goal
    public void LoseLife1()
    {
        lives1--;
        lifeText1.text = "Lives: " + lives1.ToString();

        // Check if player 1 has no more lives and activate end game conditions
        if (lives1 < 1)
        {
            loseObject1.SetActive(true);
            time.text = "";
            pauseButton.onClick.Invoke();

            // Display appropriate components depending on game mode (double or single player)
            if (singleMode)
            {
                FindObjectOfType<AudioManager>().Stop("Background_3");
                FindObjectOfType<AudioManager>().Play("Defeat");

            }
            else
            {
                FindObjectOfType<AudioManager>().Stop("Background_2");
                FindObjectOfType<AudioManager>().Play("Victory");
            }

        }
    }

    // Removes life from player 2 if a ball hits their goal
    public void LoseLife2()
    {
        lives2--;
        lifeText2.text = "Lives: " + lives2.ToString();

        // Check if player 2 has no more lives and activate end game conditions
        if (lives2 < 1)
        {
            loseObject2.SetActive(true);
            time.text = "";
            FindObjectOfType<AudioManager>().Stop("Background_2");
            FindObjectOfType<AudioManager>().Play("Victory");
            pauseButton.onClick.Invoke();
        }
    }

}
