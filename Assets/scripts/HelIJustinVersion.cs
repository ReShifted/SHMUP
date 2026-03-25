using UnityEngine;

public class HelIJustinVersion : MonoBehaviour
{

    public float timer = 0f;
    public float moveDuration = 3f;
    public float speed = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Helicopter moves forward for 3 seconds, stops and then continues moving forward without stopping after 7 seconds
    void MoveHelicopter()
    {
        while (timer < moveDuration)
        {
            timer += Time.deltaTime;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (timer >= 7f)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
