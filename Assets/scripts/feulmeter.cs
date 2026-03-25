using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class feulmeter : MonoBehaviour
{

    public manager Manager;
    public float feul = 100;
    public float timer = 1f;
    public float currenttime = 0f;

    public Range feulrange = new Range(0, 100);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        feuldown();
        
    }
    public void feuldown()
    {

        if (Time.time >= currenttime + timer && feul > 0)
        {
            currenttime = Time.time;
            feul = feul - 1f;
        }
        else if (feul <= 0)
        {
            SceneManager.LoadScene("restartscreen");
        }
    }
}
