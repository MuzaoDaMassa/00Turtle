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

    void Start()
    {
        Time.timeScale = 1;
        speedLevel = 0;
        jumpLevel = 0;
        lifeLevel = 0;
        coldDownLevel = 0;
    }


    void Update()
    {
        buffPoints_Text.text = buffPoints.ToString();

        CheckSpeedLevel();
        CheckLifeLevel();
        CheckColdDownLevel();
        CheckJumpLevel();




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

    private void CheckSpeedLevel()
    {
        if(CheckBuffPoints() > 0)
        {
            if (speedLevel == 0)
            {
                speedButton[0].GetComponent<Button>().interactable = true;
                speedButton[0].GetComponent<Image>().sprite = speedImage[0];
            }

            else if (speedLevel == 1)
            {
                speedButton[0].GetComponent<Button>().interactable = false;
                speedButton[0].GetComponent<Image>().sprite = speedImage[3];
                speedButton[1].GetComponent<Button>().interactable = true;
                speedButton[1].GetComponent<Image>().sprite = speedImage[1];
            }

            else if (speedLevel == 2)
            {
                speedButton[0].GetComponent<Button>().interactable = false;
                speedButton[0].GetComponent<Image>().sprite = speedImage[3];
                speedButton[1].GetComponent<Button>().interactable = false;
                speedButton[1].GetComponent<Image>().sprite = speedImage[4];
                speedButton[2].GetComponent<Button>().interactable = true;
                speedButton[2].GetComponent<Image>().sprite = speedImage[2];
            }

            else if (speedLevel == 3)
            {
                speedButton[0].GetComponent<Button>().interactable = false;
                speedButton[1].GetComponent<Button>().interactable = false;
                speedButton[2].GetComponent<Button>().interactable = false;
                speedButton[0].GetComponent<Image>().sprite = speedImage[3];
                speedButton[1].GetComponent<Image>().sprite = speedImage[4];
                speedButton[2].GetComponent<Image>().sprite = speedImage[5];
            }
        }
        else
        {
            for (int i = speedLevel; i < 3; i++)
            {
                speedButton[i].GetComponent<Button>().interactable = false;
                speedButton[i].GetComponent<Image>().sprite = speedImage[i + 6];
            }
        }
    }

    private void CheckLifeLevel()
    {
        if (CheckBuffPoints() > 0)
        {
            if (lifeLevel == 0)
            {
                lifeButton[0].GetComponent<Button>().interactable = true;
                lifeButton[0].GetComponent<Image>().sprite = lifeImage[0];
            }

            else if (lifeLevel == 1)
            {
                lifeButton[0].GetComponent<Button>().interactable = false;
                lifeButton[0].GetComponent<Image>().sprite = lifeImage[3];
                lifeButton[1].GetComponent<Button>().interactable = true;
                lifeButton[1].GetComponent<Image>().sprite = lifeImage[1];
            }

            else if (lifeLevel == 2)
            {
                lifeButton[0].GetComponent<Button>().interactable = false;
                lifeButton[0].GetComponent<Image>().sprite = lifeImage[3];
                lifeButton[1].GetComponent<Button>().interactable = false;
                lifeButton[1].GetComponent<Image>().sprite = lifeImage[4];
                lifeButton[2].GetComponent<Button>().interactable = true;
                lifeButton[2].GetComponent<Image>().sprite = lifeImage[2];
            }

            else if (lifeLevel == 3)
            {
                lifeButton[0].GetComponent<Button>().interactable = false;
                lifeButton[1].GetComponent<Button>().interactable = false;
                lifeButton[2].GetComponent<Button>().interactable = false;
                lifeButton[0].GetComponent<Image>().sprite = lifeImage[3];
                lifeButton[1].GetComponent<Image>().sprite = lifeImage[4];
                lifeButton[2].GetComponent<Image>().sprite = lifeImage[5];
            }
        }
        else
        {
            for (int i = lifeLevel; i < 3; i++)
            {
                lifeButton[i].GetComponent<Button>().interactable = false;
                lifeButton[i].GetComponent<Image>().sprite = lifeImage[i + 6];
            }
        }
    }

    private void CheckColdDownLevel()
    {
        if (CheckBuffPoints() > 0)
        {
            if (coldDownLevel == 0)
            {
                coldDownButton[0].GetComponent<Button>().interactable = true;
                coldDownButton[0].GetComponent<Image>().sprite = coldDownImage[0];
            }

            else if (coldDownLevel == 1)
            {
                coldDownButton[0].GetComponent<Button>().interactable = false;
                coldDownButton[0].GetComponent<Image>().sprite = coldDownImage[3];
                coldDownButton[1].GetComponent<Button>().interactable = true;
                coldDownButton[1].GetComponent<Image>().sprite = coldDownImage[1];
            }

            else if (coldDownLevel == 2)
            {
                coldDownButton[0].GetComponent<Button>().interactable = false;
                coldDownButton[0].GetComponent<Image>().sprite = coldDownImage[3];
                coldDownButton[1].GetComponent<Button>().interactable = false;
                coldDownButton[1].GetComponent<Image>().sprite = coldDownImage[4];
                coldDownButton[2].GetComponent<Button>().interactable = true;
                coldDownButton[2].GetComponent<Image>().sprite = coldDownImage[2];
            }

            else if (coldDownLevel == 3)
            {
                coldDownButton[0].GetComponent<Button>().interactable = false;
                coldDownButton[1].GetComponent<Button>().interactable = false;
                coldDownButton[2].GetComponent<Button>().interactable = false;
                coldDownButton[0].GetComponent<Image>().sprite = coldDownImage[3];
                coldDownButton[1].GetComponent<Image>().sprite = coldDownImage[4];
                coldDownButton[2].GetComponent<Image>().sprite = coldDownImage[5];
            }
        }
        else
        {
            for (int i = coldDownLevel; i < 3; i++)
            {
                coldDownButton[i].GetComponent<Button>().interactable = false;
                coldDownButton[i].GetComponent<Image>().sprite = coldDownImage[i + 6];
            }
        }
    }

    private void CheckJumpLevel()
    {
        if (CheckBuffPoints() > 0)
        {
            if (jumpLevel == 0)
            {
                jumpButton[0].GetComponent<Button>().interactable = true;
                jumpButton[0].GetComponent<Image>().sprite = jumpImage[0];
            }

            else if (jumpLevel == 1)
            {
                jumpButton[0].GetComponent<Button>().interactable = false;
                jumpButton[0].GetComponent<Image>().sprite = jumpImage[3];
                jumpButton[1].GetComponent<Button>().interactable = true;
                jumpButton[1].GetComponent<Image>().sprite = jumpImage[1];
            }

            else if (jumpLevel == 2)
            {
                jumpButton[0].GetComponent<Button>().interactable = false;
                jumpButton[0].GetComponent<Image>().sprite = jumpImage[3];
                jumpButton[1].GetComponent<Button>().interactable = false;
                jumpButton[1].GetComponent<Image>().sprite = jumpImage[4];
                jumpButton[2].GetComponent<Button>().interactable = true;
                jumpButton[2].GetComponent<Image>().sprite = jumpImage[2];
            }

            else if (jumpLevel == 3)
            {
                jumpButton[0].GetComponent<Button>().interactable = false;
                jumpButton[1].GetComponent<Button>().interactable = false;
                jumpButton[2].GetComponent<Button>().interactable = false;
                jumpButton[0].GetComponent<Image>().sprite = jumpImage[3];
                jumpButton[1].GetComponent<Image>().sprite = jumpImage[4];
                jumpButton[2].GetComponent<Image>().sprite = jumpImage[5];
            }
        }
        else
        {
            for (int i = jumpLevel; i < 3; i++)
            {
                jumpButton[i].GetComponent<Button>().interactable = false;
                jumpButton[i].GetComponent<Image>().sprite = jumpImage[i + 6];
            }
        }
    }


    //Botoes
    public void SpeedUpgrade()
    {
        speedLevel++;
        CheckSpeedLevel();
        buffPoints--;
    }

    public void LifeUpgrade()
    {
        lifeLevel++;
        CheckLifeLevel();
        buffPoints--;
    }

    public void ColdDownUpgrade()
    {
        coldDownLevel++;
        CheckColdDownLevel();
        buffPoints--;
    }

    public void JumpUpgrade()
    {
        jumpLevel++;
        CheckJumpLevel();
        buffPoints--;
    }

    public void BuffPointAbsorbed()
    {
        buffPoints++;
    }
   
}
