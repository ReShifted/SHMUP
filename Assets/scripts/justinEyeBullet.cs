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

        rb.linearVelocity = new Vector3(-speed, 0, 0); // set initial bullet movement

        Invoke(nameof(DestroySelf), 2f); // destroy bullet after 2 seconds
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If enemy bullet is parried by player
        if (other.CompareTag("PARRYIT") && this.CompareTag("EnemyBullet"))
        {
            int playerBulletLayer = LayerMask.NameToLayer("PlayerBullet");
            gameObject.layer = playerBulletLayer;
            this.tag = "PlayerBullet";
            transform.Rotate(0f, 0f, 180f); // flip bullet direction

            CancelInvoke(nameof(DestroySelf));
            Invoke(nameof(DestroySelf), destroyTime); // extend bullet life after parry

            rb.linearVelocity = -rb.linearVelocity * 2f; // reverse and speed up

            Timemanager.DoSlowmotion(); // trigger slow motion
            soundmanager.instance.PlayParrySound(parrySound, transform); // play parry sound
        }
        // If player bullet is parried
        else if (other.CompareTag("PARRYIT") && this.CompareTag("PlayerBullet"))
        {
            rb.linearVelocity *= 2f; // speed up bullet
            soundmanager.instance.PlayParrySound(parrySound, transform);
        }
        // Destroy bullet on hitting player or enemy
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