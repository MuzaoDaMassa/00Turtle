using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuffOrb : MonoBehaviour
{
    
    public GameObject canvas;

    private GameObject buffMenu;


    void Start()
    {
        if (canvas == null)
        {
            canvas = GameObject.Find("Canvas");
        }

        buffMenu = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("BuffMenu"));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            buffMenu.GetComponent<BuffMenu>().BuffPointAbsorbed();
            Destroy(this.gameObject);
        }
    }
}
