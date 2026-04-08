using UnityEngine;

public class HelIJustinVersion : MonoBehaviour
{
    public float timer = 0f; // counts time
    public float moveDuration = 3f; // how long it moves first
    public float resumeTime = 7f; // when it moves again
    public float speed = 3f; // movement speed

    public float health = 100f; // helicopter health

    private float[] angles = { 5f, 0f, -5f }; // bullet angles
    private float lastFireTime = 0f; // last time it shot
    public feulmeter Feulmeter; // fuel meter reference
    public GameObject bulletheli; // bullet object
    public float projectilespeed = 35f; // bullet speed

    private EnemyDamageIndicator damageIndicator; // show damage effect

    private void Awake()
    {
        Feulmeter = FindFirstObjectByType<feulmeter>(); // find fuel meter
    }

    void Start()
    {
        damageIndicator = GetComponent<EnemyDamageIndicator>(); // get damage effect
    }

    void Update()
    {
        timer += Time.deltaTime; // add time

        if (timer < moveDuration || timer >= resumeTime)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); // move left
        }

        HeliSpreadShot(); // shoot bullets
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(10f); // lose 10 health
        }

        if (collision.gameObject.CompareTag("EnemyKiller"))
        {
            Destroy(gameObject); // destroy immediately
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(20f); // lose 20 health
        }

        if (other.CompareTag("EnemyKiller"))
        {
            Destroy(gameObject); // destroy immediately
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage; // reduce health

        if (damageIndicator != null)
        {
            damageIndicator.Flash(); // show damage flash
        }

        if (health <= 0f)
        {
            Destroy(gameObject); // destroy if dead
            Feulmeter.feulup(); // add fuel
        }
    }

    private void HeliSpreadShot()
    {
        if (Time.time >= lastFireTime + 2f)
        {
            lastFireTime = Time.time; // set last fire time

            foreach (float angle in angles)
            {
                Quaternion rotation = transform.rotation * Quaternion.Euler(0, 0, angle); // set bullet angle
                GameObject bullet = Instantiate(bulletheli, transform.position, rotation); // make bullet

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = -bullet.transform.right * projectilespeed; // make bullet move
                }
            }
        }
    }
}