using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBottle : MonoBehaviour
{
    public float _impulse;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(JumpAround());
    }

    IEnumerator JumpAround()
    {
        rb2d.AddForce((Vector2.up + (Vector2.left/2)) * _impulse);
        yield return new WaitForSeconds(2.0f);
        rb2d.AddForce((Vector2.up + Vector2.right/2) * _impulse);
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(JumpAround());
    }

    private void OnCollisionEnter2D(Collision2D other)
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
