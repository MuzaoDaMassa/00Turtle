using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuffMenu : MonoBehaviour
{
    [SerializeField]
    Text buffPoints_Text;
    private int buffPoints;

    [SerializeField]
    Sprite[] speedImage, jumpImage, lifeImage, coldDownImage; //0,1,2 = lv1,lv2,lv3(color); 3,4,5 = lv1,lv2,lv3(light-gray); 6,7,8 = lv1,lv2,lv3(dark-gray);

    [SerializeField]
    GameObject[] speedButton, jumpButton, lifeButton, coldDownButton;

    private int speedLevel, jumpLevel, lifeLevel, coldDownLevel;

    private bool speedLevelOne, speedLevelTwo, speedLevelThree;
    private bool jumpLevelOne, jumpLevelTwo, jumpLevelThree;
    private bool lifeLevelOne, lifeLevelTwo, lifeLevelThree;
    private bool coldDownLevelOne, coldDownLevelTwo, coldDownLevelThree;

    void Start()
    {
        speedLevel = 1;
        jumpLevel = 1;
        lifeLevel = 1;
        coldDownLevel = 1;
    }


    void Update()
    {
        buffPoints_Text.text = buffPoints.ToString();

        if(CheckBuffPoints() > 0)
        {
            if(CheckSpeedLevel() == 1)
            {
                speedButton[0].GetComponent<Button>().interactable = true;
                speedButton[0].GetComponent<Image>().sprite = speedImage[0];
            }

            else if(CheckSpeedLevel() == 2)
            {
                speedButton[0].GetComponent<Button>().interactable = false;
                speedButton[0].GetComponent<Image>().sprite = speedImage[3];
                speedButton[1].GetComponent<Button>().interactable = true;
                speedButton[1].GetComponent<Image>().sprite = speedImage[1];
            }

            else if(CheckSpeedLevel() == 3)
            {
                speedButton[1].GetComponent<Button>().interactable = false;
                speedButton[1].GetComponent<Image>().sprite = speedImage[4];
                speedButton[2].GetComponent<Button>().interactable = true;
                speedButton[2].GetComponent<Image>().sprite = speedImage[2];
            }
        }

        else
        {
            for(int i = 0; i < 3; i++)
            {
                speedButton[i].GetComponent<Button>().interactable = false;
                speedButton[i].GetComponent<Image>().sprite = speedImage[i+6];
                coldDownButton[i].GetComponent<Button>().interactable = false;
                coldDownButton[i].GetComponent<Image>().sprite = coldDownImage[i + 6];
                lifeButton[i].GetComponent<Button>().interactable = false;
                lifeButton[i].GetComponent<Image>().sprite = lifeImage[i + 6];
                jumpButton[i].GetComponent<Button>().interactable = false;
                jumpButton[i].GetComponent<Image>().sprite = jumpImage[i + 6];
            }
        }

        // Código de teste para aumentar pontos de habilidade 
        if (Input.GetKeyDown(KeyCode.C))
        {
            buffPoints++;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (buffPoints > 0)
            {
                buffPoints--;
            }
        }
        //---------------------------------------------------
    }

    private int CheckBuffPoints()
    {
        return buffPoints;
    }

    private int CheckSpeedLevel()
    {
        return speedLevel;
    }

    private int CheckLifeLeve()
    {
        return lifeLevel;
    }

    private int CheckColdDownLevel()
    {
        return coldDownLevel;
    }

    private int CheckJumpLevel()
    {
        return jumpLevel;
    }

    public void SpeedUpgrade()
    {
        if(CheckBuffPoints() > 0)
        {
            buffPoints--;
            if(CheckSpeedLevel() == 1)
            {
                buffPoints--;
                speedLevel = 2;
            }

            else if(CheckSpeedLevel() == 2)
            {
                buffPoints--;
                speedLevel = 3;
            }

            else
            {
                Debug.Log("Buff already maximized");
            }
        }
    }

    public void LifeUpgrade()
    {

    }

    public void ColdDownUpgrade()
    {

    }

    public void JumpUpgrade()
    {

    }

   
}
