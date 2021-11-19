using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu_Obj, controlsMenu_Obj;

    void Start()
    {
        controlsMenu_Obj.SetActive(false);
        mainMenu_Obj.SetActive(true);
    }

    public void OpenControlsMenu()
    {
        mainMenu_Obj.SetActive(false);
        controlsMenu_Obj.SetActive(true);
    }

    public void BackToMainMenu()
    {
        controlsMenu_Obj.SetActive(false);
        mainMenu_Obj.SetActive(true);
    }
}
