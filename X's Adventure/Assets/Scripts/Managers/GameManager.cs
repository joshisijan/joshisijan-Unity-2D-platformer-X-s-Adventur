using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance;

    public LevelStats levelStats;
    public PlayerStats playerStats;
    Text coinText, heartText;
    Animator anim;
    Transform player;
    Canvas gameOverCanvas;

    [HideInInspector]
    public bool levelCompleted = false;
    [HideInInspector]
    public bool playerDead = false;
    [HideInInspector]
    public int hearts = 3;
    int coinCollected = 0;

    [HideInInspector]
    public bool isPaused = false;


    private void Awake()
    {
        //if(instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //DontDestroyOnLoad(gameObject);
        coinText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>();
        heartText = GameObject.FindGameObjectWithTag("HeartText").GetComponent<Text>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas").GetComponent<Canvas>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
        playerDead = false;
        hearts = playerStats.health;
    }


    private void Update()
    {
        if(coinCollected == levelStats.coinCount)
        {
            levelCompleted = true;
        }
        coinText.text = coinCollected + "/" + levelStats.coinCount;
        heartText.text = Convert.ToString(hearts);
    }

    public void IncreaseCoin()
    {
        if(coinCollected < levelStats.coinCount)
        {
            coinCollected++; 
        }
    }

    public void IncreaseHealth()
    {
        hearts++;
        if(hearts > playerStats.maxHealth)
        {
            hearts = playerStats.maxHealth;
        }
    }

    public void DecreaseHealth()
    {
        hearts--;
        if (hearts <= 0)
        {
            hearts = 0;
            playerDead = true;
            PlayerDead();
        }
    }

    void PlayerDead()
    {
        anim.SetTrigger("isDead");
        StartCoroutine("GameOver");
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.4f);
        PauseGame();
        gameOverCanvas.enabled = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
