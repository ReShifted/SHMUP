using UnityEngine;

public class EyeBullet : MonoBehaviour
{
    public TimeManager Timemanager;
    private Rigidbody rb;
    private float speed = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timemanager = FindFirstObjectByType<TimeManager>();
        //if (Timemanager == null) Debug.LogWarning("TimeManager not found. Assign in Inspector for better performance.");
        rb.linearVelocity = new Vector3(-speed,0,0);
        Invoke(nameof(DestroySelf), 4f); // schedule removable destroy
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
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
        } else if (other.CompareTag("PARRYIT") && this.CompareTag("PlayerBullet"))
        {
            rb.linearVelocity = rb.linearVelocity * 2f;
        }
    }
}
