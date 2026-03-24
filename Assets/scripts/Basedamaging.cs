using UnityEngine;

public class Basedamaging : MonoBehaviour
{
    public playerHP playerHP;
    public int damage = 5;
    protected override void DamagePlayer()
    {
        playerHP = GameObject.Find("Player").GetComponent<playerHP>();

        if (playerHP != null)
        {
            playerHP.TakeDamage(damage);
        }
    }
}
