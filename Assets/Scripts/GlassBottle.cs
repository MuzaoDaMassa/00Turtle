using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBottle : MonoBehaviour
{
    public float _impulse;
    public AudioClip deathSFX;

    private Rigidbody2D rb2d;
    private AudioSource audioSource;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(deathSFX);
            other.gameObject.GetComponent<Player_Controller>().TakeDamage();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Projectile")
        {
            audioSource.PlayOneShot(deathSFX);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
