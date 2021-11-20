using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyProjectile : MonoBehaviour
{
    public float _speed;

    public AudioClip shotFiredSFX;

    private Vector2 _direction;

    private SpriteRenderer playerSR;
    private GameObject player;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerSR = player.GetComponent<SpriteRenderer>();  
    }


    private void Start()
    {
        audioSource.PlayOneShot(shotFiredSFX);

        if (playerSR.flipX)
        {
            _direction = Vector2.left;
        }
        else
        {
            _direction = Vector2.right;
        }

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
        if(other.gameObject.tag == "Boss") // Adicionei tag para o projetil "atravessar" o orb, mas podemos remover isso
        {
            Debug.Log("Here");
            other.gameObject.GetComponent<Boss>().TakeDamage();
            Destroy(gameObject);
            
        }
        else if (other.gameObject.tag != "Orb" && other.gameObject.tag != "HealthRegen")
        {
            Destroy(this.gameObject);
        }
    }

}
