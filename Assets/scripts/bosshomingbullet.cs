using UnityEngine;

public class bosshomingbullet : MonoBehaviour
{
    public float speed = 0.01f;
    [SerializeField] private Transform player2;
    [Range(0f, 1f)] public float homingStrength = 0.05f;

    private Rigidbody rb;
    private bool canHome = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player2 = playerObj.transform;
        }

        Invoke(nameof(EnableHoming), 1f);

        Destroy(gameObject, 3f);
    }

    void EnableHoming()
    {
        canHome = true;
    }

    void FixedUpdate()
    {
        if (player2 == null || rb == null) return;

        Vector3 currentVelocity = rb.linearVelocity;

        if (canHome)
        {
            float targetY = player2.position.y;
            float desiredYVelocity = (targetY - transform.position.y) * homingStrength;

            Vector3 targetVelocity = new Vector3(-speed, desiredYVelocity, 0f);
            rb.linearVelocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
        }
        else
        {
            rb.linearVelocity = new Vector3(-speed, currentVelocity.y, 0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform target)
    {
        player2 = target;
    }
}