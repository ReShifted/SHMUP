using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health = 500f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}