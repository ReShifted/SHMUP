using UnityEngine;

public class JustinBomberScript : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private Transform player2;
    [Range(0f, 1f)] public float homingStrength = 0.3f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player2 = playerObj.transform;
        }
    }

    void FixedUpdate()
    {
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
            float targetY = transform.position.y;

            if (player2 != null)
            {
                targetY = player2.position.y;
            }

            float homingSpeed = speed * homingStrength;
            float newY = Mathf.MoveTowards(
                transform.position.y,
                targetY,
                homingSpeed * Time.fixedDeltaTime
            );

            float vy = (newY - transform.position.y) / Time.fixedDeltaTime;
            rb.linearVelocity = new Vector3(-speed, vy, 0f);
        }
        else
        {
            Vector3 pos = transform.position;
            pos += Vector3.left * speed * Time.fixedDeltaTime;

            if (player2 != null)
            {
                float homingSpeed = speed * homingStrength;
                pos.y = Mathf.MoveTowards(
                    pos.y,
                    player2.position.y,
                    homingSpeed * Time.fixedDeltaTime
                );
            }

            transform.position = pos;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("EnemyKiller"))
        {
            Destroy(gameObject);
        }
    }
}