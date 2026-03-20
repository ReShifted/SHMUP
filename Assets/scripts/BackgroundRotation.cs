using UnityEngine;

public class BackgroundRotation : MonoBehaviour
{
    public int speed = 25;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
