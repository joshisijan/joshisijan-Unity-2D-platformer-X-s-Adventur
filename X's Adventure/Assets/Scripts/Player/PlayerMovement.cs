using System.Collections;
using UnityEngine;


[DefaultExecutionOrder(-100)]
public class PlayerMovement : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameManager gameManager;
    public AudioManager audioManager;
    public Joystick joystick;
    public float horizontal;
    public Rigidbody2D rb;
    public Animator anim;
    public JumpButton jumpButton;

    float movementSpeed;
    float jumpForce;
    bool onGround = false;
    bool jumpTrigger = false;

    float cayoteConstant = 0.1f;


    void Awake()
    {
        movementSpeed = playerStats.movementSpeed;
        jumpForce = playerStats.jumpForce;
    }

    private void Update()
    {
        if (gameManager.playerDead) return;

        //get horizontal value from joystick
        horizontal = joystick.Horizontal;

        //get jump value from button

        jumpTrigger = jumpButton.JumpPressed;

        //For flipping player
        Flip();
    }

    private void FixedUpdate()
    {
        JumpAndFallAnimation();
        if (gameManager.playerDead) return;
        HorizontalMovement();

        if (jumpTrigger && onGround)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground") || other.transform.CompareTag("Enemy"))
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            StartCoroutine(CayotePhenomenon());
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            onGround = true;
        }
    }


    // flip player
    void Flip()
    {
        if(horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }else if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }


    //horizontal movement
    void HorizontalMovement()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = horizontal * Time.fixedDeltaTime * movementSpeed;
        if(!onGround)
            velocity.x /= 2;
        rb.velocity = velocity;
        if(horizontal != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        onGround = false;
        Vector2 velocity = rb.velocity;
        velocity.y = jumpForce * Time.fixedDeltaTime;
        rb.velocity = velocity;
    }

    void JumpAndFallAnimation()
    {
        if (!onGround)
        {
            anim.SetFloat("verticalVelocity", rb.velocity.y);
        }
        else
        {
            anim.SetFloat("verticalVelocity", 0);
        }
    }

    IEnumerator CayotePhenomenon()
    {
        yield return new WaitForSeconds(cayoteConstant);
        onGround = false;
    }
}
