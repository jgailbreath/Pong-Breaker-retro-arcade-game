using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuScript : MonoBehaviour
{
    private bool paused = false;
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Title");
    }

    public void PlayAgain()
    {
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if(paused == false)
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
