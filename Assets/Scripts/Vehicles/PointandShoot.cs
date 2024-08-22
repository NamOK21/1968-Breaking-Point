using UnityEngine;

public class PointandShoot : MonoBehaviour
{
    public GameObject bulletstart;
    public GameObject bulletprefab;
    public GameObject gun;
    public GameObject crosshair;

    public float bulletSpeed;
    private Vector3 target;
    public int damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - bulletstart.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            // Shoot
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            firebullet(direction, rotationZ);
        }
    }
    void firebullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletprefab);
        b.transform.position = gun.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(b, 2.0f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

        Stationary stationary = hitInfo.GetComponent<Stationary>();
        if (stationary != null)
        {
            stationary.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
