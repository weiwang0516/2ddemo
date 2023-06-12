using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private PlayerMoveMent player;
    private Boss boss;
    public bool gameOver;
    public bool bossisDead;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Update()
    {
        if (player != null)
        {
            gameOver = player.isDead;
        }
        if (boss != null)
        {
            bossisDead = boss.isDead;
        }
        UImanager.instance.GameOverPanel(gameOver);
    }
    public void IsPlayer(PlayerMoveMent controller)
    {
        player = controller;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.DeleteKey("playerHealth");
    }
    public void MenuLevel()
    {
        SceneManager.LoadScene("SampleScene_5");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("sceneIndex"))
            SceneManager.LoadScene(PlayerPrefs.GetInt("sceneIndex"));
        else
            NewGame();
    }
    public void BossLevel()
    {
        SceneManager.LoadScene("SampleScene_4");
    }

    public void Close()
    { 
       Application.Quit();
    }
    //保存血量  playerprefs
    public float LoadHealth()
    {
        if (!PlayerPrefs.HasKey("playerHealth"))
            PlayerPrefs.SetFloat("playerHealth", 20f);
        float currentHealth = PlayerPrefs.GetFloat("playerHealth");
        return currentHealth;
    }
    public float SaveHealth()//实现 下一关血量数据加载
    {
        PlayerPrefs.SetFloat("playerHealth", player.health);
        PlayerPrefs.SetInt("sceneIndex", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.Save();
        return player.health;
    }

}
