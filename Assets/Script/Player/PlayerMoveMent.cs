using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour,IDamageable
{
    public float moveSpeed = 300f;
    public float jumpForce = 600f;
    public float health;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Collider2D _collider2d;
    public Transform _transformcheck;
    public LayerMask _layermask;
    private ScreenFlash _screenFlash;
    public bool isGround,isJump;//是否在地面 是否跳跃
    bool jumpPressed;//是否按下跳跃键
    int jumpCound;//跳跃次数
    public bool isDead;
    public GameObject gun;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider2d = GetComponent<Collider2D>();
        _screenFlash = GetComponent<ScreenFlash>();
        health = GameManager.instance.LoadHealth();
        UImanager.instance.currentHealth = health;
        UImanager.instance.Health(0);
        GameManager.instance.IsPlayer(this);
    }

    void Update()
    {
        _animator.SetBool(AnimatorHash.dead, isDead);
        if (isDead)
        {
            gun.SetActive(false);
            return;
        }
        if(Input.GetButtonDown("Jump") && jumpCound > 0)
            jumpPressed = true;
        
    }
    private void FixedUpdate()
    {
        if (isDead)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }
        //检测是否在地面
        isGround = Physics2D.OverlapCircle(_transformcheck.position,0.2f, _layermask);
        MoveMent();
        Jump();
        PlayerAnimator();
    }
    void MoveMent()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector2(horizontalMove * moveSpeed * Time.deltaTime, _rigidbody.velocity.y);
        if (horizontalMove !=0)
        {
            transform.localScale = new Vector3(horizontalMove,1,1);
        }
    }

    public void StepAudio()
    {
        AudioManager.PlayerRunAudio();
    }
    void Jump()
    {
        if (isGround)
        {
            jumpCound = 2;
            isJump = false;
            _rigidbody.gravityScale = 1.0f;
        }
        if (jumpPressed && isGround)
        {
            AudioManager.PlayerJumpAudio();
            isJump = true;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce * Time.deltaTime);
            jumpCound--;
            jumpPressed = false;   
        }
        else if (jumpPressed && jumpCound > 0 && isJump)
        {
            AudioManager.PlayerJumpAudio();
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce * Time.deltaTime);
            jumpCound--;
            jumpPressed = false;
            _rigidbody.gravityScale = 4.0f;
        }
        if (!isGround)
        {
            _rigidbody.gravityScale = 4.0f;
        }
    }
    void PlayerAnimator()
    {
        _animator.SetFloat(AnimatorHash.speed, Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        if (isGround)
        {
            _animator.SetBool(AnimatorHash.isfall, false);
        }
        else if (!isGround && _rigidbody.velocity.y > 0)
        {
            _animator.SetBool(AnimatorHash.isjump, true);
            _animator.SetBool(AnimatorHash.isfall, false);
        }
        else if (_rigidbody.velocity.y < 0)
        {
            _animator.SetBool(AnimatorHash.isjump, false);
            _animator.SetBool(AnimatorHash.isfall, true);
        }
    }
    public void GetHit(int damage)
    {
        if (!_animator.GetCurrentAnimatorStateInfo(1).IsName("player_hit"))
        {
            _screenFlash.FlashScreen();
            health -= damage;            
            if (health < 1)
            {
                health = 0;
                isDead = true;  
            }
            _animator.SetTrigger(AnimatorHash.hit);
            AudioManager.PlayerHitAudio();
            UImanager.instance.Health(damage);
        }      
    }
}
