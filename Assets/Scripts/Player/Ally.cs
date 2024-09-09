using UnityEngine;

public class Ally : MonoBehaviour
{
    // Enemy movement and animation
    public Animator animator;
    public float speed;
    public float stoppingDistance;

    // Enemy shooting
    public Transform firePoint;
    public GameObject allybullet;
    private Transform enemy;
    private float timeBtwShots;
    public float startTimeBtwShots;

    // Enemy health and death animation
    public int health = 100;
    public GameObject deathEffect;



    // Enemy movement and animation
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Attack Enemy").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, enemy.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, enemy.position, speed * Time.deltaTime);
            animator.SetFloat("Speed", Mathf.Abs(speed));
        }
        else if (Vector2.Distance(transform.position, enemy.position) < stoppingDistance)
        {
            transform.position = this.transform.position;
            animator.SetFloat("Speed", 0);
            EnemyFire();

        }

        
    }

    public void EnemyFire()
    {
        if (timeBtwShots <= 0)
        {
            // Put the code to shoot here
            Instantiate(allybullet, firePoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void TakeDamage (int damage) 
    {         
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ScoreScript.scoreValue += 1;
        GameObject a = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(a, 1f);
    }
}
