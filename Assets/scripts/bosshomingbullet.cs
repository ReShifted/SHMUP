using UnityEngine;

public class bosshomingbullet : MonoBehaviour
{
    public float speed = 0.2f;
    [SerializeField] private Transform player2;
    [Range(0f, 1f)] public float homingStrength = 0.1f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player2 = playerObj.transform;
        }
        Destroy(gameObject, 6f);
    }

    void FixedUpdate()
    {
        if (player2 == null || rb == null) return;
        Vector3 currentVelocity = rb.linearVelocity;
        float targetY = player2.position.y;
        float desiredYVelocity = (targetY - transform.position.y) * homingStrength;

        Vector3 targetVelocity = new Vector3(-speed, desiredYVelocity, 0f);
        rb.linearVelocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
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