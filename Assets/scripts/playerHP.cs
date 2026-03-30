using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHP : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP = 100;

    void Start()
    {
        HealthCounterPLACEHOLDER.instance.healthCounter(currentHP);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            currentHP -= 10;

            HealthCounterPLACEHOLDER.instance.healthCounter(currentHP);

            if (currentHP <= 0)
            {
                Debug.Log("Player has died.");
                SceneManager.LoadScene("restartscreen");
            }
        }
    }
}