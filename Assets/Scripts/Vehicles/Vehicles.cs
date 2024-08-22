using UnityEngine;

public class Vehicles : MonoBehaviour
{
    public int health = 100;

    public CharacterController2D controller;
    public Animator animator;
    public GameObject Deadge;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    // Movement control and animation
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    private void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }

    void Die()
        {
        Debug.Log("Player died");
        Instantiate(Deadge, transform.position, Quaternion.identity);
        Destroy(gameObject);
        }
    }
}
