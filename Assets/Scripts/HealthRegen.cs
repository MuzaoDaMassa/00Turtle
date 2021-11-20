using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    [SerializeField]
    GameObject player_obj;

    private void Start()
    {
        if(player_obj == null)
        {
            player_obj = GameObject.FindGameObjectWithTag("Player");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(player_obj.GetComponent<Player_Controller>()._hp < player_obj.GetComponent<Player_Controller>()._maxHp) 
            {
                player_obj.GetComponent<Player_Controller>()._hp++;
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Full hp");
            }
        }
    }
}
