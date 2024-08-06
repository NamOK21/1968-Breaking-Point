using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public int damage = 25;
    public Rigidbody2D rb;

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        // Bullets fly right to left
        rb.velocity = transform.right * -speed;
        Destroy(this.gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}

