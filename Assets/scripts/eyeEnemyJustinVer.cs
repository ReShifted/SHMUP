using UnityEngine;

public class eyeEnemyJustinVer : MonoBehaviour
{
    public float timer = 0f;
    public float moveDuration = 3f;
    public float resumeTime = 7f;
    public float speed = 3f;

    public float health = 100f;
    public feulmeter Feulmeter;
    private float FireCooldown = 0.5f;
    public GameObject bulleteye;
    public float projectilespeed = 6f;

    private EnemyDamageIndicator damageIndicator;

    void Start()
    {
        damageIndicator = GetComponent<EnemyDamageIndicator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer < moveDuration || timer >= resumeTime)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        shootBullet();
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

        if (damageIndicator != null)
            damageIndicator.Flash();

        if (health <= 0f)
        {
            Destroy(gameObject);
            Feulmeter.feulup();
        }
    }

    private void shootBullet()
    {
        if (Time.time >= FireCooldown)
        {
            GameObject bullet = Instantiate(bulleteye, transform.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.left * projectilespeed;
            }
            FireCooldown = Time.time + 2f;
        }
    }
}