using JetBrains.Annotations;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP = 100;
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
}
