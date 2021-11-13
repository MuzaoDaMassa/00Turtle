using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuffMenu : MonoBehaviour
{
    [SerializeField]
    GameObject[] buffButton_Object;
    [SerializeField]
    GameObject[] speedButton_Upgrades,cdReduction_Upgrades, lifeButton_Upgrades, jumpButton_Upgrades;
    [SerializeField]
    Text buffPoints_Text;

    private int buffPoints = 0;
    private int spd = 0;
    private int cdr = 0;
    private int life = 0;
    private int jump = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            if(i != 1)
            {
                speedButton_Upgrades[i] = null;
                cdReduction_Upgrades[i] = null;
                lifeButton_Upgrades[i] = null;
                jumpButton_Upgrades[i] = null;
            }
            else
            {
                speedButton_Upgrades[i].GetComponent<Button>().enabled = false;
                speedButton_Upgrades[i].GetComponent<Image>().color = Color.gray;
                cdReduction_Upgrades[i].GetComponent<Button>().enabled = false;
                cdReduction_Upgrades[i].GetComponent<Image>().color = Color.gray;
                lifeButton_Upgrades[i].GetComponent<Button>().enabled = false;
                lifeButton_Upgrades[i].GetComponent<Image>().color = Color.gray;
                jumpButton_Upgrades[i].GetComponent<Button>().enabled = false;
                jumpButton_Upgrades[i].GetComponent<Image>().color = Color.gray;
            }
        } 
    }

    void Update()
    {
        buffPoints_Text.text = buffPoints.ToString();

        CheckBuffPoints();

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

    public void CheckBuffPoints()
    {
        if (buffPoints == 0)
        {
            for (int i = 0; i < buffButton_Object.Length; i++)
            {
                buffButton_Object[i].GetComponent<Button>().enabled = false;
                buffButton_Object[i].GetComponent<Image>().color = Color.gray;
            }
        }
        else if (buffPoints > 0)
        {
            if(spd > 0)
            {
                speedButton_Upgrades[spd].GetComponent<Button>().enabled = true;
                speedButton_Upgrades[spd].GetComponent<Image>().color = Color.white;
            }
            if(cdr > 0)
            {
                cdReduction_Upgrades[cdr].GetComponent<Button>().enabled = true;
                cdReduction_Upgrades[cdr].GetComponent<Image>().color = Color.white;
            }
            if(life > 0)
            {
                lifeButton_Upgrades[life].GetComponent<Button>().enabled = true;
                lifeButton_Upgrades[life].GetComponent<Image>().color = Color.white;
            }
            if(jump > 0)
            {
                jumpButton_Upgrades[jump].GetComponent<Button>().enabled = true;
                jumpButton_Upgrades[jump].GetComponent<Image>().color = Color.white;
            }
            for (int i = 0; i < buffButton_Object.Length; i++)
            {
                buffButton_Object[i].GetComponent<Button>().enabled = true;
                buffButton_Object[i].GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void Speed()
    {
        if(spd < 4)
        {
            spd++;
            buffPoints--;
        }
    }

    public void CooldDownReduction()
    {
        if(cdr < 4)
        {
            cdr++;
            buffPoints--;
        }
    }

    public void Life()
    {
        if(life < 4)
        {
            life++;
            buffPoints--;
        }
    }

    public void Jump()
    {
        if (jump < 4)
        {
            jump++;
            buffPoints--;
        }
    }
}
