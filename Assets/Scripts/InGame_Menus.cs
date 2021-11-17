using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGame_Menus : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu_obj;
    [SerializeField]
    GameObject buffMenu_obj;

    private bool pauseMenuIsOpen, buffMenuIsOpen;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuIsOpen)
            {
                pauseMenu_obj.SetActive(true);
                pauseMenuIsOpen = true;
                Time.timeScale = 0;
            }
            else if(pauseMenuIsOpen && buffMenuIsOpen)
            {
                buffMenu_obj.SetActive(false);
                buffMenuIsOpen = false;
            }
            else if(pauseMenuIsOpen && !buffMenuIsOpen)
            {
                pauseMenu_obj.SetActive(false);
                pauseMenuIsOpen = false;
                Time.timeScale = 1;
            }
        }
    }

    public void OpenBuffMenuButton()
    {
        if(!buffMenuIsOpen)
        {
            buffMenu_obj.SetActive(true);
            buffMenuIsOpen = true;
        }
    }

    public void CloseBuffMenuButton()
    {
        buffMenu_obj.SetActive(false);
        buffMenuIsOpen = false;
    }

    public void ClosePauseMenuButton()
    {
        pauseMenu_obj.SetActive(false);
        pauseMenuIsOpen = false;
    }
}
