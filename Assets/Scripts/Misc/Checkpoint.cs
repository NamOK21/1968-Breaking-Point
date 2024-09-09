using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public BoxCollider2D trigger;
    public HealthBar healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();  
        if (player != null)
            player.currentHealth = player.health;
            healthBar.SetHealth(player.currentHealth);
            trigger.enabled = false;
    }
}
