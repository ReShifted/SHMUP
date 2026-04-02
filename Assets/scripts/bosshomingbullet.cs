using UnityEngine;

public class bosshomingbullet : MonoBehaviour
{
    public soundmanager soundmanager;
    private TimeManager timeManager;
    public float speed = 0.01f;
    [SerializeField] private Transform player2;
    [Range(0f, 1f)] public float homingStrength = 0.05f;
    [SerializeField] private Transform boss;
    private Rigidbody rb;
    private bool canHome = false;
    private bool targetplayer = true;
    public AudioClip parrySound;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        timeManager = FindFirstObjectByType<TimeManager>();
        GameObject bossObj = GameObject.FindGameObjectWithTag("Enemy");
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player2 = playerObj.transform;
        }
        if (bossObj != null)
        {
            boss = bossObj.transform;
        }

        Invoke(nameof(EnableHoming), 1f);
        Invoke(nameof(DestroySelf), 2f);
    }
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
    void EnableHoming()
    {
        canHome = true;
    }

    void FixedUpdate()
    {
        if (player2 == null || rb == null) return;

        Vector3 currentVelocity = rb.linearVelocity;

        if (canHome==true && targetplayer == true)
        {
            float targetY = player2.position.y;
            float desiredYVelocity = (targetY - transform.position.y) * homingStrength;

            Vector3 targetVelocity = new Vector3(-speed, desiredYVelocity, 0f);
            rb.linearVelocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
        } else if (canHome==true && targetplayer==false)
        {
            float targetY = boss.position.y;
            float desiredYVelocity = (targetY - transform.position.y) * homingStrength;

            Vector3 targetVelocity = new Vector3(-speed, desiredYVelocity, 0f);
            rb.linearVelocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);
        }
        else
        {
            rb.linearVelocity = new Vector3(-speed, currentVelocity.y, 0f);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
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
            targetplayer = false;
            CancelInvoke(nameof(DestroySelf));
            Invoke(nameof(DestroySelf), 2f);

            rb.linearVelocity = -rb.linearVelocity * 2f;

            timeManager.DoSlowmotion();
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

    public void SetTarget(Transform target)
    {
        player2 = target;
    }
}