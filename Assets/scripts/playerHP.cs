using UnityEngine;

public class playerHP : MonoBehaviour
{
 public int maxHP = 100;
    private int currentHP;
    void Update()
    {
        
    }

    void Start()
{
    currentHP = maxHP;

    HealthCounterPLACEHOLDER.instance.healthCounter(currentHP);
}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Basedamaging basedamaging = collision.gameObject.GetComponent<Basedamaging>();
            if (basedamaging != null)
            {
                basedamaging.DamagePlayer(this);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            die();
        }

        // Update UI
        HealthCounterPLACEHOLDER.instance.healthCounter(currentHP);
    }

    public void die()
    {
        Debug.Log("Player has died.");
        Destroy(gameObject);
    }
}
