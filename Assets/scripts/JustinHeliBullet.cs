using UnityEngine;

public class JustinHeliBullet : MonoBehaviour
{
    public TimeManager Timemanager;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timemanager = FindFirstObjectByType<TimeManager>();

        Destroy(gameObject, 2f);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PARRYIT") && this.CompareTag("EnemyBullet"))
        {
            this.tag = "PlayerBullet";
            CancelInvoke(nameof(DestroySelf));
            Invoke(nameof(DestroySelf), 4f);
            rb.linearVelocity = -rb.linearVelocity * 2f;
            Timemanager.DoSlowmotion();
        }
        else if (other.CompareTag("PARRYIT") && this.CompareTag("PlayerBullet"))
        {
            rb.linearVelocity = rb.linearVelocity * 2f;
        }

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}