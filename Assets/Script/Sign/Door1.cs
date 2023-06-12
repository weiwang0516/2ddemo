using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Door1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject image;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            image.SetActive(true);
            

        }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            image.SetActive(false);

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && collision.CompareTag("Player"))
        {
            GameManager.instance.SaveHealth();
            GameManager.instance.BossLevel();
        }
    }
}
