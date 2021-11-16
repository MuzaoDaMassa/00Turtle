using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticStraw : MonoBehaviour
{
    public float _speed;

    private int _seconds;
    private bool _turnRight = false;

    private SpriteRenderer spriteRenderer;

    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(CounterRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (_turnRight)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
    }

    IEnumerator CounterRoutine()
    {
        yield return new WaitForSeconds(1.0f);

        _seconds++;

        if (_seconds % 3 == 0)
        {
            _turnRight =! _turnRight;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        StartCoroutine(CounterRoutine());
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
