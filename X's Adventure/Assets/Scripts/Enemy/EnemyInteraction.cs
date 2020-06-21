using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public AudioManager audioManager;
    public Animator anim;
    public EnemyStats enemyStats;
    public EnemyAttack enemyAttack;
    public EnemyMovement enemyMovement;
    public GameObject coinPrefab;

    int health;

    private void Awake()
    {
        health = enemyStats.health;
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
        enemyAttack.isDead = true;
        enemyMovement.isDead = true;
        anim.SetTrigger("isDead");
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}
