using System.Runtime.CompilerServices;
using UnityEngine;

public class Stationary : MonoBehaviour
{
    // Enemy movement and animation
    public float stoppingDistance;

    // Enemy shooting
    public Transform firePoint;
    public GameObject enemybullet;
    private Transform player;
    private Transform ally;
    private float timeBtwShots;
    public float startTimeBtwShots;

    // Enemy health and death
    public int health = 100;
    public GameObject deathEffect;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ally = GameObject.FindGameObjectWithTag("Allies").transform;
        
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = this.transform.position;
            EnemyFire();
        }

        if (Vector2.Distance(transform.position, ally.position) < stoppingDistance)
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
            Instantiate(enemybullet, firePoint.position, Quaternion.identity);
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
