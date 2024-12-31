using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            audioManager.PlaySFX(audioManager.gunfire);

        }
    }

    void Shoot()
    {
        // Shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
