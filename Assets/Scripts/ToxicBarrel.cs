using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicBarrel : MonoBehaviour
{
    public float _speed;
    public GameObject _explosionPrefab;

    private int _counter = 3;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FloatingRoutine());
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator FloatingRoutine()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        yield return new WaitForSeconds(1.0f);
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(FloatingRoutine());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = false;
            other.gameObject.GetComponent<Player_Controller>().Damage();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Projectile")
        {
            if (_counter > 1)
            {
                _counter--;
                Destroy(other.gameObject);
            }
            else
            {
                spriteRenderer.enabled = false;
                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
        
    }
}
