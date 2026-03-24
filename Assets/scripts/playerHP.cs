using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP=100;
    public HealthCounterPLACEHOLDER HEalthCounter;
    void Update()
    {
        maxHP = currentHP;
    }

    void Start()
{
    //currentHP = maxHP;

    HEalthCounter.healthCounter(currentHP);
}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            currentHP = currentHP - 10;
            if (currentHP <= 0)
            {
                Debug.Log("Player has died.");
                SceneManager.LoadScene("restartscreen");
              //  die();
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
