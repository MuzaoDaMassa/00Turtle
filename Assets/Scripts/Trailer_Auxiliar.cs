using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trailer_Auxiliar : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private float initialPosX, initialPosY;

    [SerializeField]
    GameObject menuEnemies;
    [SerializeField]
    Button[] enemies;

    void Start()
    {
        initialPosX = player.GetComponent<Transform>().position.x;
        initialPosY = player.GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(initialPosX);
        Debug.Log(initialPosY);

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayerPosition();
        }


        //Ideia de criar um menu para poder instanciar inimigos no mapa para auxiliar na gravação do trailer
        if (Input.GetKeyDown(KeyCode.C))
        {
            menuEnemies.SetActive(true);
        }
    }

    private void ResetPlayerPosition()
    {
        player.transform.position = new Vector2(initialPosX, initialPosY);
    }

}
