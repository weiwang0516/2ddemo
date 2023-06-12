using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird2 : Enemy,IDamageable
{
    public float startWaitTime;
    public float waitTime;
    public Transform movePos;
    public Transform deadEffect;
    public override void Start()
    {
        base.Start();
        targetPoint = movePos;
    }
    public override void MoveMent()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
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
        if (health < 1)
        {
            health = 0;
            isDead = true;
            //实例化死亡特效
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

    }
}
