using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float _speed;
    public float _impulse;
    public int _maxAmmo;

    public Transform groundSensor;
    public GameObject gun;
    public GameObject buoyProjectile;

    private bool _jump;
    private bool _isGrounded;
    private float _moveX;
    private float _nextFire = -1.0f;
    private float _fireRate = 0.5f;
    private float _nextDash = -1.0f;
    private float _dashRate = 0.5f;
    private int _ammo;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        _ammo = _maxAmmo;
        StartCoroutine(AmmoStorage());
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Animations();

        // CALL ATTACK FUNCTION IF LEFT MOUSE BUTTON IS PRESSED
        if (Input.GetMouseButtonDown(0) && Time.time > _nextFire && _ammo > 0)
        {
            Attack();
        }
        // CALL DASH FUNCTION IF RIGHT MOUSE BUTTON IS PRESSED
        if (Input.GetMouseButton(1) && Time.time > _nextDash)
        {
            Dash();
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(_moveX, rb2d.velocity.y);

        if (_jump)
        {
            rb2d.AddForce(Vector2.up * _impulse);
            _jump = false;
        }
    }

    private void Movement()
    {
        _moveX = Input.GetAxisRaw("Horizontal") * _speed;

        if (_moveX < 0)
        {
            spriteRenderer.flipX = true;
            gun.GetComponent<Transform>().position = new Vector2(this.transform.position.x - 1, this.transform.position.y);
        }
        else if(_moveX > 0)
        {
            spriteRenderer.flipX = false;
            gun.GetComponent<Transform>().position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
        }
    }

    private void Jump()
    {
        _isGrounded = Physics2D.Linecast(transform.position, groundSensor.transform.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _jump = true;
        }
    }

    private void Animations()
    {
        animator.SetFloat("toMove", Mathf.Abs(_moveX));
        animator.SetFloat("toJump", rb2d.velocity.y);
        
    }

    private void Attack()
    {
        _nextFire = Time.time + _fireRate;
        animator.SetTrigger("toAttack");
        Instantiate(buoyProjectile, gun.transform.position, Quaternion.identity);
        _ammo--;
        Debug.Log(_ammo);
    }

    private void Dash()
    {
        _nextDash = Time.time + _dashRate;
        animator.SetTrigger("toDash");
    }

    IEnumerator AmmoStorage()
    {
        if (_ammo >= _maxAmmo)
        {
            yield return null;
            StartCoroutine(AmmoStorage());
            
        }
        else
        {
            _ammo++;
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(AmmoStorage());
        }
    }
}
