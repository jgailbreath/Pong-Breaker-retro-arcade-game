using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menu_1_player()
    {
        //  On click of 1-player button, will load "Scene1" from build settings/scene manager
        SceneManager.LoadScene("Scene1");  
    }

    public void Menu_2_player()
    {
        //  On click of 2-player button, will load "Scene2" from build settings/scene manager
        SceneManager.LoadScene("Scene2");
    }

    public void Menu_exit()
    {
        //  On click of Exit button, will load "Exit" from build settings/scene manager
        Application.Quit();
    }

    public void Menu_demo()
    {
        //  On click of Options button, will load "Options" from build settings/scene manager
        SceneManager.LoadScene("SinglePlayerDemo");
    }
}

