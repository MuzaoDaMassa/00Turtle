using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_Test : MonoBehaviour
{
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu-TESTE");
    }

    public void InGameScene()
    {
        SceneManager.LoadScene("InGame-LEVELDESIGN");
    }

    public void PreGameScene()
    {
        SceneManager.LoadScene("Pregrame-Tutorial");
    }
    /*
    public void OptionsScene()
    {
        SceneManager.LoadScene("Options");
    }
    */

    public void QuitGame()
    {
        Application.Quit();
    }
}
