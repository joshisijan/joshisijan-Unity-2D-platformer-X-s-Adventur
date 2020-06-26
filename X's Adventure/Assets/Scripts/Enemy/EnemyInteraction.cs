using System.Collections;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public AudioManager audioManager;
    public Animator anim;
    public EnemyStats enemyStats;
    public EnemyMovement enemyMovement;
    public GameObject coinPrefab;

    int health;
    EnemyAttack enemyAttack;

    private void Awake()
    {
        health = enemyStats.health;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            if (health > 0)
            {
                IsHurt();
            }
        }
    }


    void IsHurt()
    {
        audioManager.Play("EnemyHurt");
        anim.SetTrigger("isHurt");
        health -= 1;
        if(health <= 0)
        {
            IsDead();
        }
    }

    void IsDead()
    {
        Destroy(gameObject, 0.4f);
        anim.SetTrigger("isDead");
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}
