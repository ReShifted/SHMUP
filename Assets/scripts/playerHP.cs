using UnityEngine;

public class playerHP : MonoBehaviour
{
 public int maxHP = 100;
    private int currentHP;
    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        
    }
    //player takes damage when colliding with an object with the tag EnemyBullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Basedamaging basedamaging = collision.gameObject.GetComponent<Basedamaging>();
            if (basedamaging != null)
            {
                basedamaging.DamagePlayer(GetComponent<playerHP>());
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Debug.Log("Player is dead");
        }
    }
}
