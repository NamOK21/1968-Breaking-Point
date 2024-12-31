using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Respawn values
    public Vector2 checkpointPos;
    Rigidbody2D playerrb;

    public int health = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public int live;
    public int currentLive;

    public CharacterController2D controller;
    public Animator animator;
    public GameObject Deadge;
    public GameManager gameManager;

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;
    private bool isDead = false;

    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);

        currentLive = live;

        playerrb = GetComponent<Rigidbody2D>();
        checkpointPos = transform.position;
    }

    // Movement control and animation
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Die();
            TakeLive();
            if (currentLive == 0)
            {
                gameManager.GameOver();
            }
            else
            {
                StartCoroutine(Respawn(2f));
            }
        }
    }
    public void TakeLive()
    {
        currentLive -= 1;
        LiveCounter.liveValue = currentLive;
    }

    void Die()
        {
        Debug.Log("Player died");
        GameObject a = Instantiate(Deadge, transform.position, Quaternion.identity);
        Destroy(a, 1f);
        if (currentLive == 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }


    IEnumerator Respawn(float duration)
    {
        playerrb.velocity = new Vector2(0, 0);
        playerrb.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        transform.localScale = new Vector3(0.5024842f, 0.5463118f, 0.4579695f);
        playerrb.simulated = true;
        currentHealth = health;
        healthBar.SetHealth(currentHealth);
        isDead = false;
        }
    }


