using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifeTime = 5f;
    public float bulletForce = 6.5f;
    public Rigidbody2D rb;
    public GameObject bulletImpact;

    private void Awake()
    {
        
    }

    private void Start()
    {
        rb.velocity = transform.right * bulletForce;
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("Bullet"))
        {
            Destroy(gameObject, 0.1f);
            GameObject impact = Instantiate(bulletImpact, transform.position, transform.rotation);
            Destroy(impact, 0.3f);
        }
    }
}
