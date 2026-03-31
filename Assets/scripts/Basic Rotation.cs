using UnityEngine;

public class BasicRotation : MonoBehaviour
{
    [Header("Rotation")]
    public float speed = 25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
