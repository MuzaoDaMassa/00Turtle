using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float _speed;
    public float _impulse;

    public Transform groundSensor;

    private bool _jump;
    private bool _isGrounded;
    private float _moveX;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Animations();
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
        }
        else
        {
            spriteRenderer.flipX = false;
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
        animator.SetBool("toJump", _jump);
    }
}
