using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeathHandler : MonoBehaviour
{
    public BossHealth bossHealth;

    void Update()
    {
        if (bossHealth != null && bossHealth.health <= 0f)
        {
            SceneManager.LoadScene("LIZZIE_WIN_SCREEN");
        }
    }
}