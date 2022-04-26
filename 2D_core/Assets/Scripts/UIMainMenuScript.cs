using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuScript : MonoBehaviour
{
    private bool paused = false;
    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Stop("Background_3");
        FindObjectOfType<AudioManager>().Stop("Background_2");
        SceneManager.LoadScene("Main Title Test");
    }

    public void PlayAgain()
    {
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<AudioManager>().Stop("Defeat");
        FindObjectOfType<AudioManager>().Stop("Victory");
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if (paused == false)
        {
            paused = true;
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            Time.timeScale = 1;
        }
    }
}
