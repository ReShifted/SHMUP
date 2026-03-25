using JetBrains.Annotations;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP = 100;
    public HealthCounterPLACEHOLDER HEalthCounter;
    public float feulAmount = 100f;
    public float TimeForFeulDown = 1f;

    void Update()
    {
        maxHP = currentHP;
        feul();
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
    public void feul()
    {
        if (feulAmount > 0)
        {
            feulAmount -= Time.deltaTime * (100 / TimeForFeulDown);
        }
        else if (feulAmount <= 0)
        {
            {
                SceneManager.LoadScene("restartscreen");
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

        //public void die()
        //{
        //    Debug.Log("Player has died.");
        //    Destroy(gameObject);
        //}
    }
}
