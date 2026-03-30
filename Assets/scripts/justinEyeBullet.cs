using UnityEngine;

public class justinEyeBullet : MonoBehaviour
{
    public TimeManager Timemanager;
    private Rigidbody rb;
    private float speed = 8f;
    [SerializeField] public AudioClip parrySound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timemanager = FindFirstObjectByType<TimeManager>();

        rb.linearVelocity = new Vector3(-speed, -1f, 0);

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
            rb.linearVelocity = -rb.linearVelocity * 2f;
            soundmanager.instance.PlayParrySound(parrySound,transform);
            Timemanager.DoSlowmotion();
            CancelInvoke(nameof(DestroySelf));
            Invoke(nameof(DestroySelf), 4f);
        }
        else if (other.CompareTag("PARRYIT") && this.CompareTag("PlayerBullet"))
        {
            rb.linearVelocity = rb.linearVelocity * 2f;
            soundmanager.instance.PlayParrySound(parrySound, transform);
        }

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}