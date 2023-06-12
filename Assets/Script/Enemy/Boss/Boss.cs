using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy, IDamageable
{
    private float scale = 2f;//体积
    public float startWaitTime;
    public float waitTime;
    public Transform movePos;
    public Transform deadEffect;
    //public Transform boss;
    public override void Start()
    {
        base.Start();
        targetPoint = movePos;
        UImanager.instance.bossCurrentHealth = health;
    }
  
    public override void MoveMent()
    {
        //移动
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        //攻击间隔
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                targetPoint = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        //转向
        if (transform.position.x < targetPoint.position.x)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        
    }
    public override void SwintchPoint()
    {
        targetPoint = GetRandomPos();
    }

    Transform GetRandomPos() //随机获取的位置
    {
        movePos.position = new Vector2(Random.Range(pointA.position.x, pointB.position.x), Random.Range(pointA.position.y, pointB.position.y));
        return movePos;
    }

    public void GetHit(int damage)
    {
        FlashColor(flashTime);
        GameObject a = Instantiate(floatPoint, transform.position, Quaternion.identity) as GameObject;
        a.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
        health -= damage;
        UImanager.instance.BossHealth(damage);
        if (health < 1)
        {
            health = 0;
            //实例化死亡特效
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            UImanager.instance.GameVictory();
            Destroy(gameObject);

        }
        if (health == 50)
        {
            //Instantiate(boss, GetRandomPos().position, Quaternion.identity);
            transform.localScale *= scale;
            speed = 1f;
        }
    }
}
