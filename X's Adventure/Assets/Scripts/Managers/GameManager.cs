using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LevelStats levelStats;
    public PlayerStats playerStats;
    public Text coinText;
    public Text heartText;
    public Animator anim;
    public Transform player;
    public Canvas gameOverCanvas;
    public Canvas pauseCanvas;

    public bool levelCompleted = false;
    public bool playerDead = false;

    [HideInInspector]
    public int hearts = 3;
    int coinCollected = 0;

    [HideInInspector]
    public bool isPaused = false;


    private void Awake()
    {
        hearts = playerStats.health;
        isPaused = false;
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
        yield return new WaitForSeconds(1);
        player.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseCanvas.gameObject.SetActive(true);
        Debug.Log(isPaused);
    }
}
