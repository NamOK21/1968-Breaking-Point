using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public int damage = 25;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        // Bullets fly right to left
        rb.velocity = transform.right * -speed;
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {   
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

