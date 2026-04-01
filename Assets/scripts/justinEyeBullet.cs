using UnityEngine;

public class justinEyeBullet : MonoBehaviour
{
    public TimeManager Timemanager;
    private Rigidbody rb;
    private float speed = 8f;
    public float destroyTime = 4f;
    [SerializeField] public AudioClip parrySound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timemanager = FindFirstObjectByType<TimeManager>();

        rb.linearVelocity = new Vector3(-speed, 0, 0);

        Invoke(nameof(DestroySelf), 2f);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("PARRYIT") && this.CompareTag("EnemyBullet"))
    //    {

    //        rb.linearVelocity = -rb.linearVelocity * 2f;
    //        this.tag = "PlayerBullet";
    //        transform.Rotate(0f, 0f, 180f);

    //        soundmanager.instance.PlayParrySound(parrySound, transform);
    //        Timemanager.DoSlowmotion();

    //        CancelInvoke(nameof(DestroySelf));
    //        Invoke(nameof(DestroySelf), 8f);
    //    }
    //    else if (other.CompareTag("PARRYIT") && this.CompareTag("PlayerBullet"))
    //    {
    //        rb.linearVelocity *= 2f;
    //        soundmanager.instance.PlayParrySound(parrySound, transform);
    //    }

    //    if (other.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
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
        if (other.transform.root.CompareTag("Player") && this.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
        else if (other.transform.root.CompareTag("Enemy") && this.CompareTag("PlayerBullet"))
        {

            Destroy(gameObject);
        }
    }
}