using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]
    GameObject playerObj;

    private void Update()
    {
        if(playerObj.GetComponent<Player_Controller>()._hp <= 0)
        {
            SceneManager.LoadScene("InGame-LEVELDESIGN");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("InGame-LEVELDESIGN");
        }
    }
}
