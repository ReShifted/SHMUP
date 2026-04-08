using UnityEngine;

public class JustinBomberScript : MonoBehaviour
{
    public float speed = 5f; // movement speed
    [SerializeField] private Transform player2; // target player
    [Range(0f, 1f)] public float homingStrength = 0.3f; // how strong it follows player
    public feulmeter Feulmeter; // fuel meter reference
    private Rigidbody rb; // rigidbody component
    public float health = 100f; // bomber health

    private EnemyDamageIndicator damageIndicator; // show damage effect

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); // get rigidbody
        Feulmeter = FindFirstObjectByType<feulmeter>(); // find fuel meter
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player"); // find player
        if (playerObj != null)
        {
            player2 = playerObj.transform; // set player target
        }

        damageIndicator = GetComponent<EnemyDamageIndicator>(); // get damage effect
    }

    public void Start()
    {
        Destroy(this.gameObject, 10f); // destroy after 10 seconds
    }

    void FixedUpdate()
    {
        // find player if lost
        if (player2 == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player2 = playerObj.transform;
            }
        }

        if (rb != null)
        {
            // follow player vertically
            float targetY = transform.position.y;
            if (player2 != null)
            {
                targetY = player2.position.y;
            }

            float homingSpeed = speed * homingStrength;
            float newY = Mathf.MoveTowards(transform.position.y, targetY, homingSpeed * Time.fixedDeltaTime);

            float vy = (newY - transform.position.y) / Time.fixedDeltaTime;
            rb.linearVelocity = new Vector3(-speed, vy, 0f); // move bomber
        }
        else
        {
            // move without rigidbody
            Vector3 pos = transform.position;
            pos += Vector3.left * speed * Time.fixedDeltaTime;

            if (player2 != null)
            {
                float homingSpeed = speed * homingStrength;
                pos.y = Mathf.MoveTowards(pos.y, player2.position.y, homingSpeed * Time.fixedDeltaTime);
            }

            transform.position = pos; // update position
        }
    }

    private void Update()
    {
        if (health <= 0f)
        {
            Destroy(gameObject); // destroy if dead
            Feulmeter.feulup(); // add fuel
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // destroy on player hit
        }
        else if (collision.gameObject.CompareTag("EnemyKiller"))
        {
            Destroy(gameObject); // destroy on killer hit
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(20f); // lose health
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
            damageIndicator.Flash(); // show damage

        if (health <= 0f)
        {
            Feulmeter.feulup(); // add fuel
            Destroy(gameObject); // destroy bomber
        }
    }
}