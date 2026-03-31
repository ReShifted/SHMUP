using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public float maxHP = 500;
    public float currentHP = 500;
    [SerializeField] public HealthBar healthBar;

    void Start()
    {
          healthBar= FindAnyObjectByType<HealthBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            currentHP -= 10;
            healthBar.HealthDown();
            if (currentHP <= 0)
            {
                SceneManager.LoadScene("restartscreen");
            }
        }
    }
}