using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyProjectile : MonoBehaviour
{
    public float _speed;


    private SpriteRenderer playerSR;
    private Vector2 _direction;
    private GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSR = player.GetComponent<SpriteRenderer>();
        if (playerSR.flipX)
        {
            _direction = Vector2.left;
        }
        else
        {
            _direction = Vector2.right;
        }
    }

    private void Start()
    {
        StartCoroutine(DestroyRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponent<Boss>().TakeDamage();
        }
        Destroy(this.gameObject);
    }

}
