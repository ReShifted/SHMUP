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
      //whenever the player collects feul, the score will increase by 10 points
        scoretext.text = "Score: " + feulgain;
    }


}
