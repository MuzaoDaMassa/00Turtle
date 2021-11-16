using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBag : MonoBehaviour
{
    public float _speed;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
    }


    // Update is called once per frame
    void Update()
    {
        float _step = _speed * Time.deltaTime;
        Vector2 _target = player.transform.position;

        transform.position = Vector2.MoveTowards(transform.position, _target, _step);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }  
    }
}
