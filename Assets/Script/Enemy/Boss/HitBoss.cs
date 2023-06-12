using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoss : MonoBehaviour
{
    public float speed=7f;
    public GameObject bullet;
    public Transform player;
    public GameObject Muzzle;
    bool isAttack = false;
    public Boss boss;
    private float timer;
    private void Update()
    {
        if (isAttack)
        {
            Buttle();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Buttle();
            isAttack = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isAttack = false;
            
        }
    }
    private void Buttle()
    {
        timer += Time.deltaTime;
        if (timer > 3)//当timer大于3时，发射子弹，使得发射有间隙
        {
            for (int i = 0; i < 24; i++)
            {
                Quaternion bulletRot = Quaternion.Euler(0, 0, i * 15);

                // Create and configure the bullet object.
               // GameObject buttledse =  
                Instantiate(bullet, transform.position, bulletRot);
                
            }
            timer = 0;//timer重置为0
        }
    }
}
