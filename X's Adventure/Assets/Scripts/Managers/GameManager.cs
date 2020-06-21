using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelStats levelStats;
    public PlayerStats playerStats;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI heartText;
    public Animator anim;
    public Transform player;

    public bool levelCompleted = false;
    public bool playerDead = false;

    int hearts = 3;
    int coinCollected = 0;


    private void Awake()
    {
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
        Destroy(player.gameObject, 1f);
        anim.SetTrigger("isDead");
    }
}
