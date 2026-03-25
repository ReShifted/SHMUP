using UnityEngine;

public class JustinHeliBullet : MonoBehaviour
{
    public TimeManager Timemanager;
    private Rigidbody rb;
    private float speed = 1f;
    [SerializeField] public AudioClip parrySound;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timemanager = FindFirstObjectByType<TimeManager>();
        rb.linearVelocity = new Vector3(-speed, 0, 0);
        Invoke(nameof(DestroySelf), 4f); 
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
            soundmanager.instance.PlayParrySound(parrySound, transform);
        }
        else if (other.CompareTag("PARRYIT") && this.CompareTag("PlayerBullet"))
        {
            rb.linearVelocity = rb.linearVelocity * 2f;
            //   soundmanager.instance.PlaySound("parry");
            soundmanager.instance.PlayParrySound(parrySound, transform);
        }
    }
}