using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary : MonoBehaviour
{
    // Enemy movement and animation
    public float stoppingDistance;

    // Enemy shooting
    public GameObject enemybullet;
    private Transform player;
    private float timeBtwShots;
    public float startTimeBtwShots;

    // Enemy health and death
    public int health = 100;
    public GameObject deathEffect;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = this.transform.position;
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
