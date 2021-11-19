using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu_Controller : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu_Button;
    [SerializeField]
    GameObject title_Object, controls_Object, interface_background;

    private float ui_posX, ui_width;

    public void Controls()
    {
        title_Object.SetActive(false);
        mainMenu_Button.SetActive(false);
        interface_background.SetActive(false);
        controls_Object.SetActive(true);
    }

    public void BackToMainMenu()
    {
        title_Object.SetActive(true);
        mainMenu_Button.SetActive(true);
        interface_background.SetActive(true);
        controls_Object.SetActive(false);
    }
}
