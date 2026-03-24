using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP=100;
    public HealthCounterPLACEHOLDER healthCounter;
    void Update()
    {
        
    }

    void Start()
{
    //currentHP = maxHP;

    healthCounter.instance.healthCounter(currentHP);
}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            currentHP -= 10;
            healthCounter.instance.healthCounter(currentHP);
            if (currentHP <= 0)
            {
                SceneManager.LoadScene("restartscreen");
                die();
            }
        }
    }

    //public void TakeDamage(int amount)
    //{
    //    currentHP -= amount;

    //    if (currentHP <= 0)
    //    {
    //        SceneManager.LoadScene("restartscreen");
    //        die();
    //    }

    //    // Update UI
    //    HealthCounterPLACEHOLDER.instance.healthCounter(currentHP);
    //}

    public void die()
    {
        Debug.Log("Player has died.");
        Destroy(gameObject);
    }
}
