using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject a;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float positionY;


    public void MoveMent()
    {

        if (a.transform.position.y < positionY)
        {
            a.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)//如果进入检查碰撞范围  判断如果是player  tag则添加
    {
        if (collision.CompareTag("Player"))
        {
            MoveMent();
        }    
    }

}
