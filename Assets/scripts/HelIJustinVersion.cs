using UnityEngine;

public class HelIJustinVersion : MonoBehaviour
{
    public float timer = 0f;
    public float moveDuration = 3f;
    public float resumeTime = 7f;
    public float speed = 3f;

    public float health = 100f;

    private float[] angles = { 10f, 5f, 0f, -5f, -10f };
    private float lastFireTime = 0f;
    public feulmeter Feulmeter;
    public GameObject bulletheli;
    public float projectilespeed = 35f;

    void Update()
    {
        timer += Time.deltaTime;

        // Movement logic
        if (timer < moveDuration || timer >= resumeTime)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        HeliSpreadShot();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(10f);
        }

        if (collision.gameObject.CompareTag("EnemyKiller"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(10f);
        }

        if (other.CompareTag("EnemyKiller"))
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            
            Destroy(gameObject);
            Feulmeter.feulup();
        }
    }

    private void HeliSpreadShot()
    {
        if (Time.time >= lastFireTime + 2f)
        {
            lastFireTime = Time.time;

            foreach (float angle in angles)
            {
                Quaternion rotation = transform.rotation * Quaternion.Euler(0, 0, angle);

                GameObject bullet = Instantiate(bulletheli, transform.position, rotation);

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = -bullet.transform.right * projectilespeed;
                }
            }
        }
    }
}