using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyBaseState currentState; //判断当前状态为  攻击还是巡逻
    public float speed;
    public int health;
    public int animState;//控制动画参数
    //public Transform player;
    public Animator _animator;
    public Transform pointA, pointB;
    public Transform targetPoint;
    public bool isDead;

    
    [Header("敌人掉血闪烁")]
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public float flashTime;
    [Header("Attack setting")]
    public float attackRate;//攻击间隔
    private float nextAttack = 0;//下一次攻击时间
    public float attackRange;//攻击判定巨鹿

    [Header("状态机")]
    public PatrolState patrolState = new PatrolState();
    public AttackState attackState = new AttackState();

    [Header("伤害飘字")]
    public GameObject floatPoint;
    public List<Transform> attackList = new List<Transform>();
    public virtual void Init()
    {
        _animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        Init();
    }
    public virtual void Start()
    {
       
        TransitionToState(patrolState);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public  void  Update()
    {
        currentState.OnUpdate(this);
        _animator.SetInteger("state", animState);
    }

     public virtual void MoveMent()//移动转向
    {
        transform.position =Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        if (transform.position.x < targetPoint.position.x)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    public virtual void SwintchPoint()//判断里哪个点的位置远就向内个点移动
    {
        if (Mathf.Abs(pointA.transform.position.x - transform.position.x) > Mathf.Abs(pointB.transform.position.x - transform.position.x))
            targetPoint = pointA;
        else
            targetPoint = pointB;
    }
    public void TransitionToState(EnemyBaseState state)  //进入这个物体的状态
    {
        currentState = state;
        currentState.EnterState(this);
        
    }
    public void OnTriggerEnter2D(Collider2D collision)//如果进入检查碰撞范围  判断如果是player  tag则添加
    {
        if (collision.CompareTag("Player"))
            attackList.Add(collision.transform);
    }
    private void OnTriggerExit2D(Collider2D collision)//退出检查范围  删除列表list的数据
    {
        attackList.Remove(collision.transform);
    }

    public void AttackAction()//攻击玩家
    { 
       if(Vector2.Distance(transform.position,targetPoint.position) > attackRange)
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
            }
    }
    public void FlashColor(float time)
    {
        spriteRenderer.color = Color.red;
        Invoke("ResetColor",time);
    }
    void ResetColor()
    {
        spriteRenderer.color = originalColor;
    }

 }
