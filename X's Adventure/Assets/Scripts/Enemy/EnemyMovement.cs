using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public EnemyStats enemyStats;
    public Rigidbody2D rb;
    public Animator anim;
    public bool isAttacking = false;

    float activeDistance;
    float attackDistance;
    float stoppingDistance;
    float movingSpeed;
    GameObject player;
    Vector3 distanceWithPlayer;
    int horizontal = 1;
    bool isMoving = false;
    bool isRoaming = true;
    float distance;
    [HideInInspector]


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        activeDistance = enemyStats.activeDistance;
        attackDistance = enemyStats.attackDistance;
        stoppingDistance = enemyStats.stoppingDistance;
        movingSpeed = enemyStats.movementSpeed;
    }

    private void Update()
    {
        distanceWithPlayer = transform.position - player.transform.position;
        distance = distanceWithPlayer.magnitude;
        
        if(distance > activeDistance)
        {
            isRoaming = true;
        }
        else
        {
            isRoaming = false;
            if (distance <= stoppingDistance)
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }
        }

        if(!isRoaming && !isMoving && distance > stoppingDistance)
        {
            isRoaming = true;
        }

        if (distance <= attackDistance && distanceWithPlayer.y < 1 && distanceWithPlayer.y > -1) isAttacking = true;
        else isAttacking = false;

        if (isRoaming) isMoving = false;
        if (isMoving) isRoaming = false;

        Flip();
        Animate();
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 velocity = rb.velocity;
            velocity.x = movingSpeed * -distanceWithPlayer.normalized.x * Time.fixedDeltaTime;
            rb.velocity = velocity;
        }

        if (isRoaming)
        {
            Vector2 velocity = rb.velocity;
            velocity.x = movingSpeed * horizontal * Time.fixedDeltaTime;
            rb.velocity = velocity;
        }
        if (!isRoaming && !isMoving)
        {
            Vector2 velocity = rb.velocity;
            velocity.x = 0;
            rb.velocity = velocity;
        }
    }

    void Animate()
    {
        if(rb.velocity.x != 0){
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    void Flip()
    {
        if (isRoaming)
        {
            if(horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        if (isMoving)
        {
            if (distanceWithPlayer.x < 0)
            {
                if (distanceWithPlayer.x < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (distanceWithPlayer.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
            else if (distanceWithPlayer.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("Player") && isRoaming)
        {
            horizontal = -horizontal;
        }
    }
}
