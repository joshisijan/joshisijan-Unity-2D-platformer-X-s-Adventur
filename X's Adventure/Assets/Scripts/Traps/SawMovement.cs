using System.Collections;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public MovingSaw movingSaw;
    public GameManager gameManager;
    public Rigidbody2D rb;

    float movingSpeed;
    int horizontal = -1;
    float retrackTime;

    private void Awake()
    {
        movingSpeed = movingSaw.movingSpeed;
        retrackTime = movingSaw.retrackTime;
    }

    private void FixedUpdate()
    {
        MoveSaw();   
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("Player"))
        {
            horizontal = -horizontal;
        }
        else
        {
            StartCoroutine("HitPlayer");
        }
    }

    void MoveSaw()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = horizontal * Time.fixedDeltaTime * movingSpeed;
        rb.velocity = velocity;
    }

    IEnumerator HitPlayer()
    {
        horizontal = -horizontal;
        yield return new WaitForSeconds(retrackTime);
        horizontal = -horizontal;
    }
}
