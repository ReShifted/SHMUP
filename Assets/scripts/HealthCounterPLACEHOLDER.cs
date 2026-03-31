using UnityEngine;
using TMPro;

public class HealthCounterPLACEHOLDER : MonoBehaviour
{
    public static HealthCounterPLACEHOLDER instance;
    public TextMeshProUGUI healthtext;

    void Awake()
    {
        instance = this;
    }

    public void healthCounter(float currentHP)
    {
        healthtext.text = "Health: " + currentHP;
    }
}