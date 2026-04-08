using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public float health = 500f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            SceneManager.LoadScene("LIZZIE_WIN_SCREEN");
        }
    }
}