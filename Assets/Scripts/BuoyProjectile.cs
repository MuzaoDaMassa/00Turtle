using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyProjectile : MonoBehaviour
{
    public float _speed;

    private void Start()
    {
        StartCoroutine(DestroyRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
