using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{   public static Gun instance;
    public Camera _camera;
    private Vector3 mousePos;
    private Vector3 gunDirection;
    public Transform player;
    public Transform peningFire;
    private AudioSource _audioSource;
    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        ShootDirection();
       
    }
    //瞄准
    void ShootDirection()
    {
        mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (player.localScale.x < 0)
        {
            if (mousePos.x > transform.position.x)
            {
                    gunDirection = (transform.position - mousePos).normalized;
                    float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
                    transform.eulerAngles = new Vector3(0, 0, angle);
                    transform.localScale = new Vector3(1, -1, 1);
                if (Input.GetMouseButtonDown(0))
                {
                    //Transform a = Instantiate(bullet, peningFire.position, Quaternion.Euler(transform.eulerAngles = new Vector3(0, 0, angle + 180f)));
                    //Destroy(a.gameObject,1f);
                    //bulletPool.SpawnObject(peningFire.position, Quaternion.Euler(transform.eulerAngles = new Vector3(0, 0, angle + 180f)));
                    AudioManager.GunAudio();
                    ObjectPool.instance.SpawnObject(peningFire.position, Quaternion.Euler(transform.eulerAngles = new Vector3(0, 0, angle + 180f)));
                }
            }
            else
            {
                gunDirection = (mousePos - transform.position).normalized;
                float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle);
                transform.localScale = new Vector3(-1, -1, 1);
                if (Input.GetMouseButtonDown(0))
                {
                    //Transform a = Instantiate(bullet, peningFire.position, Quaternion.Euler(transform.eulerAngles));
                    //Destroy(a.gameObject, 1f);
                    //bulletPool.SpawnObject(peningFire.position, Quaternion.Euler(transform.eulerAngles));
                    AudioManager.GunAudio();
                    ObjectPool.instance.SpawnObject(peningFire.position, Quaternion.Euler(transform.eulerAngles));
                }
            }
        }
        else if (player.localScale.x > 0)
        {
            if (mousePos.x > transform.position.x)
            {
                gunDirection = (transform.position - mousePos).normalized;
                float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle);
                transform.localScale = new Vector3(-1, -1, 1);
                if (Input.GetMouseButtonDown(0))
                {
                    //Transform a =  Instantiate(bullet, peningFire.position, Quaternion.Euler(transform.eulerAngles = new Vector3(0, 0, angle + 180f)));
                    //Destroy(a.gameObject, 1f);
                    AudioManager.GunAudio();
                    ObjectPool.instance.SpawnObject(peningFire.position, Quaternion.Euler(transform.eulerAngles = new Vector3(0, 0, angle + 180f)));
                }
            }
            else
            {
                gunDirection = (mousePos - transform.position).normalized;
                float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle);
                transform.localScale = new Vector3(1, -1, 1);
                if (Input.GetMouseButtonDown(0))
                {
                    //Transform a = Instantiate(bullet, peningFire.position, Quaternion.Euler(transform.eulerAngles));
                    //Destroy(a.gameObject, 1f);
                    AudioManager.GunAudio();
                    ObjectPool.instance.SpawnObject(peningFire.position, Quaternion.Euler(transform.eulerAngles));
                }
            }
        }
        
    }

}
