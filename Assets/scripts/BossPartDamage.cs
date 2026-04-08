using UnityEngine;

public class BossPartDamage : MonoBehaviour
{
    private BossHealth boss;
    private EnemyDamageIndicator indicator;
    private float lastHitTime;
    public float hitCooldown = 0.1f;

    void Start()
    {
        boss = transform.parent.GetComponent<BossHealth>();
        indicator = transform.parent.GetComponent<EnemyDamageIndicator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet") && Time.time > lastHitTime + hitCooldown)
        {
            lastHitTime = Time.time;

            if (boss != null)
                boss.TakeDamage(10f);

            if (indicator != null)
                indicator.Flash();

            Destroy(other.gameObject);
        }
    }
}