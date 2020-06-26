using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public MovingSaw movingSaw;
    public Rigidbody2D rb;

    float movingSpeed;
    int horizontal = -1;

    private void Awake()
    {
        movingSpeed = movingSaw.movingSpeed;
    }

    private void Start()
    {
        if(Random.Range(0, 100) > 50){
            horizontal = 1;
        }
        else
        {
            horizontal = -1;
        }
    }

    private void FixedUpdate()
    {
        MoveSaw();   
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("Bullet"))
        {
            horizontal = -horizontal;
        }
    }




    void MoveSaw()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = horizontal * Time.fixedDeltaTime * movingSpeed;
        rb.velocity = velocity;
    }


}
