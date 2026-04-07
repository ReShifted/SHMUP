using UnityEngine;

public class JustinHeliBullet : MonoBehaviour
{
    public TimeManager Timemanager;
    private Rigidbody rb;

    [SerializeField] public AudioClip parrySound;
    public float projectilespeed = 35f;
    public float destroyTime = 4f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timemanager = FindFirstObjectByType<TimeManager>();

        if (rb.linearVelocity.magnitude == 0)
        {
            rb.linearVelocity = Vector3.left * projectilespeed;
        }

        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        Invoke(nameof(DestroySelf), destroyTime);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PARRYIT") && this.CompareTag("EnemyBullet"))
        {
            int playerBulletLayer = LayerMask.NameToLayer("PlayerBullet");
            gameObject.layer = playerBulletLayer;
            this.tag = "PlayerBullet";
            transform.Rotate(0f, 0f, 180f);

            CancelInvoke(nameof(DestroySelf));
            Invoke(nameof(DestroySelf), destroyTime);

            rb.linearVelocity = -rb.linearVelocity * 2f;

            Timemanager.DoSlowmotion();
            soundmanager.instance.PlayParrySound(parrySound, transform);

        }
        else if (other.CompareTag("PARRYIT") && this.CompareTag("PlayerBullet"))
        {
            rb.linearVelocity *= 2f;
            soundmanager.instance.PlayParrySound(parrySound, transform);
        }
        if (other.transform.root.CompareTag("Player")&& this.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        } else if(other.transform.root.CompareTag("Enemy")&&this.CompareTag("PlayerBullet")) 
        {

            Destroy(gameObject);
        }
    }
}