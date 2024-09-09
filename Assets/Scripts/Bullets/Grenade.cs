using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Grenade : MonoBehaviour
{
    public int  grenadeCount = 3;
    public int currentGrenadeCount;
    public float delay = 3f;
    public float radius = 5f;
    public int damage = 50;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        currentGrenadeCount = grenadeCount;

        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        GameObject a = Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                Player player = nearbyObject.GetComponent<Player>();
                Enemy enemy = nearbyObject.GetComponent<Enemy>();
                Stationary stationary = nearbyObject.GetComponent<Stationary>();

                if (player != null)
                {
                    player.TakeDamage(damage);
                }

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                if (stationary != null)
                {
                    stationary.TakeDamage(damage);
                }
            }
        }
        Destroy(gameObject);
        Destroy(a, 0.5f);
    }
}


