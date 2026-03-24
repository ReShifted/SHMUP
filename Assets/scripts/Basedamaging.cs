using UnityEngine;

public class Basedamaging : MonoBehaviour
{
    public playerHP playerHP;
    public int damage = 5;
    public void DamagePlayer(playerHP player)
    {
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
