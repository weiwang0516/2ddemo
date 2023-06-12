using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBird2 : MonoBehaviour
{
    public Transform bullet;
    public Transform player;
    private Vector3 gunDirection;
    public Transform peningFire;
    bool isAttack = false;

    float time = 0;
    private void Update()
    {
        if (isAttack)
        { 
            time = time + Time.deltaTime;
            if (time >= 2)
            {
                Buttle();
                time = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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
        gunDirection = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        Instantiate(bullet, peningFire.position, Quaternion.Euler(transform.eulerAngles));

    }

}
