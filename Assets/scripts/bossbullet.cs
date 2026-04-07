using UnityEngine;

public class bossbullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.right * speed;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    //bullet shrinks over time
    void Update()
    {
        transform.localScale *= 0.98f;
    }
}