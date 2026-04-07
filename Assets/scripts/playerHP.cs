using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public float maxHP = 500;
    public float currentHP = 500;
    [SerializeField] public HealthBar healthBar;
    public GameObject effect;

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

            GameObject gameObject = Instantiate(effect,transform);

            if (currentHP <= 0)
            {
                SceneManager.LoadScene("restartscreen");
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            currentHP -= 20;
            healthBar.HealthDown();

            GameObject gameObject = Instantiate(effect,transform);

            if (currentHP <= 0)
            {
                SceneManager.LoadScene("restartscreen");
            }
        }
    }
}