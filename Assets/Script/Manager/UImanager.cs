using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public static UImanager instance;
    [Header("player")]
    public Image healthImage;
    public float currentHealth;
    public float maxHealth = 20;
    public Text healthText;
    [Header("boss")]
    public Image bosshealthImage;
    public float bossCurrentHealth;
    public float bossMaxHealth = 100;

    public GameObject menu;


    public GameObject audioControl;
    public Slider ambientSlider;
    public Slider gunAudioSlider;
    public Slider playerSlider;
    public GameObject gameOver;
    public GameObject gameVictory;
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    //血条
    public void Health(float damage)
    {
        currentHealth -= damage;
        //healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        Amount();
    }
    public void Amount()
    {
        healthImage.fillAmount = currentHealth / maxHealth;
    }

    public void BossHealth(int damage)
    {
        bossCurrentHealth -= damage;
        //healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        BossAmount();
    }
    public void BossAmount()
    {
        bosshealthImage.fillAmount = bossCurrentHealth / bossMaxHealth;
    }
    public void PauseGame()
    {
        
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;

    }
    public void GameOverPanel(bool playerDead)
    {
        gameOver.SetActive(playerDead);
    }
    public void GameVictory()
    {
        gameVictory.SetActive(true);
    }
    public void AudioSlider()
    {
        audioControl.SetActive(true);
    }

}
