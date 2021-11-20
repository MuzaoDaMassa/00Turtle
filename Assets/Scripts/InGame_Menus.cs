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
    [SerializeField]
    GameObject player_obj;

    private bool pauseMenuIsOpen, buffMenuIsOpen;

    private void Start()
    {
        Time.timeScale = 1;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuIsOpen)
            {
                player_obj.GetComponent<Player_Controller>().noMenuIsOpen = false;
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
                player_obj.GetComponent<Player_Controller>().noMenuIsOpen = true;
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

    public void ReturnToMainMenuButton()
    {

    }

}
