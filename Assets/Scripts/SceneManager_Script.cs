using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_Script : MonoBehaviour
{
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void InGameScene()
    {
        SceneManager.LoadScene("InGame");
    }

    public void PreGameScene()
    {
        SceneManager.LoadScene("PreGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
