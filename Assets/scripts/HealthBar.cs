using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public playerHP PlayerHP;
    public float Healthrange = 1f;
    public float currentHealth;
    public float maxHealth;



    private void Awake()
    {
        PlayerHP = FindAnyObjectByType<playerHP>();
        currentHealth = PlayerHP.currentHP;
        maxHealth = PlayerHP.maxHP;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        Healthrange = Mathf.Clamp01(currentHealth / maxHealth);
        transform.localScale = new Vector3(Healthrange, transform.localScale.y, transform.localScale.z);
    }

    public void SetHealth(float health)
    {
        transform.localScale = new Vector3(health / PlayerHP.maxHP, transform.localScale.y, transform.localScale.z);
    }

    public void HealthDown() { 
        currentHealth -= 10f;
        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            SceneManager.LoadScene("restartscreen");
        }
    }
}
