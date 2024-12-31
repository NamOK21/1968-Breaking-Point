using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Player player;
    public BoxCollider2D trigger;
    public HealthBar healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();  
        if (player != null)
            player.currentHealth = player.health;
            healthBar.SetHealth(player.currentHealth);
            player.checkpointPos = transform.position;
            trigger.enabled = false;
    }
}
