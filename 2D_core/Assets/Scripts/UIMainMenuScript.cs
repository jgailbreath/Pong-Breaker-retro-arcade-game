using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuScript : MonoBehaviour
{
    private bool paused = false;
    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Stop("Hard Rock Anthem");
        FindObjectOfType<AudioManager>().Stop("Epic Drums");
        SceneManager.LoadScene("Main Title");
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
