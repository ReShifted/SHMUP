using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    //HP
    public float health = 500f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            // Load the win screen when the boss is defeated
            SceneManager.LoadScene("LIZZIE_WIN_SCREEN");
        }
    }
}