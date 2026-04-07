using UnityEngine;

public class BossPartDamage : MonoBehaviour
{
    private BossHealth boss;
    private EnemyDamageIndicator indicator;

    void Start()
    {
        boss = GetComponentInParent<BossHealth>();
        indicator = GetComponentInParent<EnemyDamageIndicator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            if (boss != null)
            {
                boss.TakeDamage(10f);
            }

            if (indicator != null)
            {
                indicator.Flash();
            }

            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            if (indicator != null)
            {
                indicator.Flash();
            }
        }
    }
}