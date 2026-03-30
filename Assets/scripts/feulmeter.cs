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
    public float feulgain = 0f;

    // replace the Range field
    public float feulrange = 1f; // normalized 0..1

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        feuldown();
        feulrange = Mathf.Clamp01(feul / 100f);
        transform.localScale = new Vector3(feulrange, transform.localScale.y, transform.localScale.z);
    }

    public void feuldown()
    {
        if (Time.time >= currenttime + timer && feul > 0)
        {
            currenttime = Time.time;
            feul -= 1f;
        }
        else if (feul <= 0)
        {
            SceneManager.LoadScene("restartscreen");
        }
    }
    public void feulup()
    {
        feul += 10f;
        feulgain += 10f;
        if (feul > 100f)
        {
            feul = 100f;
        }
    }
}
