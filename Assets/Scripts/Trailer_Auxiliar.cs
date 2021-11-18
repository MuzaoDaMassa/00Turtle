using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trailer_Auxiliar : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private float initialPosX, initialPosY;
    private int ammoController;

    private bool enemyMenuIsOpen = false;
    private bool btnOneClick = false;
    private bool btnTwoClick = false;
    private bool btnThreeClick = false;
    private bool btnFourClick = false;
    private bool btnFiveClick;
    [SerializeField]
    GameObject menuEnemies;
    [SerializeField]
    GameObject[] enemyPrefab;

    [SerializeField]
    Texture2D[] enemyImage;
    [SerializeField]
    Texture2D standardCursor;

    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;


    void Start()
    {
        initialPosX = player.GetComponent<Transform>().position.x;
        initialPosY = player.GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayerPosition();
        }

        //Ideia de criar um menu para poder instanciar inimigos no mapa para auxiliar na gravação do trailer
        EnemySpawnerMenu();
    }

    private void ResetPlayerPosition()
    {
        player.transform.position = new Vector2(initialPosX, initialPosY);
    }

    public void EnemyOne()
    {
        if (!btnOneClick)
        {
            Cursor.SetCursor(enemyImage[0], hotSpot, cursorMode);
            btnTwoClick = false;
            btnThreeClick = false;
            btnFourClick = false;
            btnOneClick = true;
            btnFiveClick = false;
        }
    }

    public void EnemyTwo()
    {
        if (!btnTwoClick)
        {
            Cursor.SetCursor(enemyImage[1], hotSpot, cursorMode);
            btnOneClick = false;
            btnThreeClick = false;
            btnFourClick = false;
            btnTwoClick = true;
            btnFiveClick = false;
        }
    }

    public void EnemyThree()
    {
        if (!btnThreeClick)
        {
            Cursor.SetCursor(enemyImage[2], hotSpot, cursorMode);
            btnOneClick = false;
            btnTwoClick = false;
            btnFourClick = false;
            btnThreeClick = true;
            btnFiveClick = false;
        }
    }

    public void EnemyFour()
    {
        if (!btnFourClick)
        {
            Cursor.SetCursor(enemyImage[3], hotSpot, cursorMode);
            btnOneClick = false;
            btnTwoClick = false;
            btnThreeClick = false;
            btnFourClick = true;
            btnFiveClick = false;
        }
    }

    public void BuffOrb()
    {
        if (!btnFiveClick)
        {
            Cursor.SetCursor(enemyImage[4], hotSpot, cursorMode);
            btnOneClick = false;
            btnTwoClick = false;
            btnThreeClick = false;
            btnFourClick = false;
            btnFiveClick = true;
        }
    }

    private void EnemySpawnerMenu()
    {
        if (Input.GetKeyDown(KeyCode.T) && !enemyMenuIsOpen)
        {
            ammoController = player.GetComponent<Player_Controller>()._maxAmmo;
            Time.timeScale = 0;
            player.GetComponent<Player_Controller>()._maxAmmo = -1;
            menuEnemies.SetActive(true);
            enemyMenuIsOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.T) && enemyMenuIsOpen)
        {
            menuEnemies.SetActive(false);
            enemyMenuIsOpen = false;
            player.GetComponent<Player_Controller>()._maxAmmo = ammoController;
            Time.timeScale = 1;
        }

        if (Input.GetButtonDown("Fire1") && btnOneClick)
        {
            Vector3 playerPos = new Vector2(player.GetComponent<Transform>().position.x + 10f, player.GetComponent<Transform>().position.y);
            Instantiate(enemyPrefab[0], playerPos, Quaternion.identity);
            Debug.Log("enemy1");
            Cursor.SetCursor(standardCursor, hotSpot, cursorMode);
            btnOneClick = false;
            player.GetComponent<Player_Controller>()._maxAmmo = ammoController;
        }

        else if (Input.GetButtonDown("Fire1") && btnTwoClick)
        {
            Vector3 playerPos = new Vector2(player.GetComponent<Transform>().position.x + 10f, player.GetComponent<Transform>().position.y);
            Instantiate(enemyPrefab[1], playerPos, Quaternion.identity);
            Debug.Log("enemy2");
            Cursor.SetCursor(standardCursor, hotSpot, cursorMode);
            btnTwoClick = false;
            player.GetComponent<Player_Controller>()._maxAmmo = ammoController;
        }

        else if (Input.GetButtonDown("Fire1") && btnThreeClick)
        {
            Vector3 playerPos = new Vector2(player.GetComponent<Transform>().position.x + 10f, player.GetComponent<Transform>().position.y);
            Instantiate(enemyPrefab[2], playerPos, Quaternion.identity);
            Debug.Log("enemy3");
            Cursor.SetCursor(standardCursor, hotSpot, cursorMode);
            btnThreeClick = false;
            player.GetComponent<Player_Controller>()._maxAmmo = ammoController;
        }

        else if (Input.GetButtonDown("Fire1") && btnFourClick)
        {
            Vector3 playerPos = new Vector2(player.GetComponent<Transform>().position.x + 10f, player.GetComponent<Transform>().position.y);
            Instantiate(enemyPrefab[3], playerPos, Quaternion.identity);
            Debug.Log("enemy4");
            Cursor.SetCursor(standardCursor, hotSpot, cursorMode);
            btnFourClick = false;
            player.GetComponent<Player_Controller>()._maxAmmo = ammoController;
        }

        else if (Input.GetButtonDown("Fire1") && btnFiveClick)
        {
            Vector3 playerPos = new Vector2(player.GetComponent<Transform>().position.x + 10f, player.GetComponent<Transform>().position.y);
            Instantiate(enemyPrefab[4], playerPos, Quaternion.identity);
            Debug.Log("orb");
            Cursor.SetCursor(standardCursor, hotSpot, cursorMode);
            btnFiveClick = false;
            player.GetComponent<Player_Controller>()._maxAmmo = ammoController;
        }
    }

}
