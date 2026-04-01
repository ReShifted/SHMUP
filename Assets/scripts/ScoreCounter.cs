using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{

    //public static ScoreCounter instance;
    public TextMeshProUGUI scoretext;

    void Start()
    {
        //instance = this;
    }

    void Update()
    {
        
    }

    public void scoreCounter(float feulgain)
    {
        Debug.Log(feulgain);
        scoretext.text = "Score: " + feulgain;
    }


}
