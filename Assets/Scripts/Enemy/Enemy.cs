using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy movement and animation
    public Animator animator;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    // Enemy shooting
    public GameObject enemybullet;
    private Transform player;
    private float timeBtwShots;
    public float startTimeBtwShots;

    // Enemy health and death animation
    public int health = 100;
    public GameObject deathEffect;



    // Enemy movement and animation
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            animator.SetFloat("Speed", Mathf.Abs(speed));
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            animator.SetFloat("Speed", 0);
            EnemyFire();

        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            animator.SetFloat("Speed", Mathf.Abs(speed));
            EnemyFire();
        }

        
    }

    public void EnemyFire()
    {
        if (timeBtwShots <= 0)
        {
            // Put the code to shoot here
            Instantiate(enemybullet, transform.position, Quaternion.identity);
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
