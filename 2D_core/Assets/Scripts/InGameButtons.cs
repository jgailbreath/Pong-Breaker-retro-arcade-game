using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour
{
    public void InGameButtons_BackToMain()
    {
        SceneManager.LoadScene("Main Title");
    }

    public void InGameButtons_Pause()
    {
        GetComponent<Button>().onClick.AddListener(TogglePause);
    }

    public void TogglePause()
    {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
    }
}
