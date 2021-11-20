using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //temporariamente

public class Player_Controller : MonoBehaviour
{
    #region Public Variables
    public float _speed;
    public float _impulse;
    public float _ammoRechargeTime;
    public int _hp, _maxHp;
    public int _maxAmmo;
    public Transform groundSensor;
    public GameObject gun;
    public GameObject buoyProjectile;
    public bool noMenuIsOpen = true;
    #endregion

    #region Private Variables
    private bool _jump;
    private bool _isGrounded;
    private bool _inDash = false;
    private float _moveX;
    private float _nextFire = -1.0f;
    private float _fireRate = 0.5f;
    private float _nextDash = -1.0f;
    private float _dashRate = 0.5f;
    private int _ammo;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    #endregion

    [SerializeField]
    Text maxAmmo_Text, currentAmmo_Text;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        _ammo = _maxAmmo;
        _hp = _maxHp;
        maxAmmo_Text.text = _maxAmmo.ToString();
        currentAmmo_Text.text = _ammo.ToString();
        maxAmmo_Text.text = _maxAmmo.ToString();
        currentAmmo_Text.text = _ammo.ToString();
        StartCoroutine(AmmoStorage());
    }

    void Update()
    {
        Movement();
        Jump();
        Animations();

        // CALL ATTACK FUNCTION IF LEFT MOUSE BUTTON IS PRESSED
        if (Input.GetMouseButtonDown(0) && Time.time > _nextFire && _ammo > 0 && noMenuIsOpen)
        {
            Attack();
        }
        // CALL DASH FUNCTION IF RIGHT MOUSE BUTTON IS PRESSED
        if (Input.GetMouseButton(1) && Time.time > _nextDash && noMenuIsOpen)
        {
            Dash();
        }

        if (_hp <= 0)
        {
            SceneManager.LoadScene("InGame");
        }

        UpdateCurrentAmmoUI();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(_moveX, rb2d.velocity.y);

        if (_jump)
        {
            rb2d.AddForce(Vector2.up * _impulse);
            animator.SetFloat("toJump", rb2d.velocity.y);
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
        _isGrounded = Physics2D.Linecast(transform.position, groundSensor.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _jump = true;
        }
    }

    private void Animations()
    {
        animator.SetFloat("toMove", Mathf.Abs(_moveX));
        //animator.SetFloat("toJump", rb2d.velocity.y);
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
        StartCoroutine(DashInvunerabilityRoutine());
    }

    private IEnumerator DashInvunerabilityRoutine()
    {
        _inDash = true;
        yield return new WaitForSeconds(0.3f);
        _inDash = false;
    }

    private IEnumerator AmmoStorage()
    {
        if (_ammo >= _maxAmmo)
        {
            yield return null;
            StartCoroutine(AmmoStorage());
            
        }
        else
        {
            _ammo++;
            yield return new WaitForSeconds(_ammoRechargeTime);
            StartCoroutine(AmmoStorage());
        }
    }

    private IEnumerator DamageAnimation()
    {
        if (_hp >= 1)
        {
            for (int i = 0; i < 6; i++)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }


    public void TakeDamage()
    {
        if (!_inDash && _hp >=1)
        {
            _hp--;
            StartCoroutine(DamageAnimation());
        }
    }

    private void UpdateCurrentAmmoUI()
    {
        currentAmmo_Text.text = _ammo.ToString();
    }

    #region Buffs

    public void RaiseMoveSpeed()
    {
        _speed += 1.5f;
    }

    public void RaiseJumpHeight()
    {
        _impulse += 20.0f;
    }

    public void IncreaseHealth()
    {
        _hp++;
        _maxHp++;
        _maxHp++;
    }

    public void DecreaseCdr()
    {
        _ammoRechargeTime -= 0.5f;
    }

    #endregion
}

