using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D _rigidbody2d;
    public float arrawDistance;
    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        _rigidbody2d.velocity = transform.right * speed;
        float distance = (Gun.instance.peningFire.position - transform.position).sqrMagnitude;
        if (distance > arrawDistance)
        {
            ObjectPool.instance.ReturnObject(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IDamageable>().GetHit(2);
            ObjectPool.instance.ReturnObject(gameObject);
        }
        if (collision.CompareTag("Ground"))
        {
            ObjectPool.instance.ReturnObject(gameObject);
        }
        
    }


}
