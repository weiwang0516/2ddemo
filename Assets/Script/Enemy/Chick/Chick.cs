using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : Enemy, IDamageable
{
    public Transform deadEffect;
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
