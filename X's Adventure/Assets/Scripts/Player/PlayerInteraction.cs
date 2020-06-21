using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public Animator anim;
    public GameManager gameManager;
    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Heart"))
        {
            audioManager.Play("PlayerPowerUp");
            gameManager.IncreaseHealth();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Gold"))
        {
            audioManager.Play("PlayerPowerUp");
            gameManager.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            isHurt();
        }
    }

    void isHurt()
    {
        audioManager.Play("PlayerHurt");
        // for animation
        anim.SetTrigger("isHurt");
        gameManager.DecreaseHealth();
    }
}
