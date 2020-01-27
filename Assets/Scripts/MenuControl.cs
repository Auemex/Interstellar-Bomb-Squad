using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject PauseUI;
    public GameObject Canvas;

    public void ButtonStart()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

    public void EasyMode()
    {
        SceneManager.LoadScene("EasyLevel");
    }

    public void HardMode()
    {
        SceneManager.LoadScene("HardLevel");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Unpause()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
