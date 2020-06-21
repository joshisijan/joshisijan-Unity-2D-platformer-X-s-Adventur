using UnityEngine;

public class Door : MonoBehaviour
{
    public GameManager gameManager;
    public Animator anim;

    private void Update()
    {
        if (gameManager.levelCompleted)
        {
            anim.SetBool("isOpened", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameManager.levelCompleted)
        {
            Debug.Log("going to next level");
        }
    }
}
