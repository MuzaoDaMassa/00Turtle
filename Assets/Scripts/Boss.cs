using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public int _bossHp;
    public float _impulse;
    public bool _isFlipped = false;
    public bool _isEnraged = false;

    //private float _jumpDistance;
   

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeDamage()
    {
        _bossHp--;
        StartCoroutine(DamageAnimation());
    
    }

    private IEnumerator DamageAnimation()
    {
        if (_bossHp >= 1)
        {
            for (int i = 0; i < 6; i++)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    public void LookAtPlayer()
    {
        Vector3 _flipped = transform.localScale;
        _flipped.z = -1.0f;

        if (transform.position.x > player.transform.position.x && _isFlipped)
        {
            transform.localScale = _flipped;
            transform.Rotate(0.0f, 180.0f, 0.0f);
            _isFlipped = false;
        }
        else if (transform.position.x < player.transform.position.x && !_isFlipped)
        {
            transform.localScale = _flipped;
            transform.Rotate(0.0f, 180.0f, 0.0f);
            _isFlipped = true;
        }
    }

    private IEnumerator JumpAttackRoutine()
    {
        yield return new WaitForSeconds(1.0f);

        //_jumpDistance = player.transform.position.x - transform.position.x;

        if (_isEnraged)
        {
            _impulse = 500f;

            if (_isFlipped)
            {
                rb2d.AddForce((Vector2.up + (Vector2.right / 2)) * (_impulse));
                yield return new WaitForSeconds(2.5f);
            }
            else
            {
                rb2d.AddForce((Vector2.up + (Vector2.left / 2)) * (_impulse));
                yield return new WaitForSeconds(2.5f);
            }
        }
        else
        {
            if (_isFlipped)
            {
                rb2d.AddForce((Vector2.up + (Vector2.right / 2)) * (_impulse));
                yield return new WaitForSeconds(2.5f);
            }
            else
            {
                rb2d.AddForce((Vector2.up + (Vector2.left / 2)) * (_impulse));
                yield return new WaitForSeconds(2.5f);
            }

        }

        StartCoroutine(JumpAttackRoutine());
    }

    public void CallJumpAttack()
    {
        StartCoroutine(JumpAttackRoutine());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player_Controller>().Damage();
        }
    }
}


