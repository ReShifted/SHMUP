using UnityEngine;

public class bossbullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    public AudioClip parrySound;
    private TimeManager timeManager;

    private bool isPlayerBullet = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.right * speed;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        timeManager = FindFirstObjectByType<TimeManager>();

        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PARRYIT"))
        {
            if (!isPlayerBullet)
            {
                isPlayerBullet = true;

                int playerBulletLayer = LayerMask.NameToLayer("PlayerBullet");
                gameObject.layer = playerBulletLayer;
                this.tag = "PlayerBullet";

                rb.linearVelocity = -rb.linearVelocity;
                transform.Rotate(0f, 0f, 180f);

                CancelInvoke();
                Invoke(nameof(DestroySelf), 2f);

                if (timeManager != null)
                    timeManager.DoSlowmotion();

                if (soundmanager.instance != null)
                    soundmanager.instance.PlayParrySound(parrySound, transform);
            }
            else
            {
                rb.linearVelocity *= 2f;

                if (soundmanager.instance != null)
                    soundmanager.instance.PlayParrySound(parrySound, transform);
            }

            return;
        }

        if (other.transform.root.CompareTag("Player") && !isPlayerBullet)
        {
            Destroy(gameObject);
        }
        else if (other.transform.root.CompareTag("Enemy") && isPlayerBullet)
        {
            Destroy(gameObject);
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.localScale *= 0.98f;
    }
}