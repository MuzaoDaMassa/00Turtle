using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuffMenu : MonoBehaviour
{
    [SerializeField]
    GameObject[] buffButton_Object;
    [SerializeField]
    Text buffPoints_Text;

    private int buffPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        buffPoints_Text.text = buffPoints.ToString();

        if(buffPoints == 0)
        {
            for (int i = 0; i < buffButton_Object.Length; i++)
            {
                buffButton_Object[i].GetComponent<Button>().enabled = false;
                buffButton_Object[i].GetComponent<Image>().color = Color.gray;
            }
        }
        else if(buffPoints > 0)
        {
            for (int i = 0; i < buffButton_Object.Length; i++)
            {
                buffButton_Object[i].GetComponent<Button>().enabled = true;
                buffButton_Object[i].GetComponent<Image>().color = Color.white;
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
}
