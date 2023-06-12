using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D _rigidbody2d;
    private void Start()
    {
        
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //transform.Translate(Vector3.forward * 0.3f, Space.Self);
        _rigidbody2d.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<IDamageable>().GetHit(1);
            Destroy(gameObject);
            //ObjectPool.instance.ReturnObject(gameObject);
        }
        if (collision.CompareTag("Ground"))
        {
            //ObjectPool.instance.ReturnObject(gameObject);
            Destroy(gameObject);
        }

    }

}
