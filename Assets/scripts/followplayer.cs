using UnityEngine;

public class followplayer : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public Transform player;

    public float followAmount = 0.1f;

    public float minRotationX = -30f;
    public float maxRotationX = 30f;

    void Update()
    {
        RotateCameraWithPlayer();

    }

    void RotateCameraWithPlayer()
    {
        float normalizedY = Mathf.InverseLerp(-6.1f, 6.1f, player.position.y);

        float targetRotationX = Mathf.Lerp(minRotationX, maxRotationX, normalizedY);

        float currentX = transform.eulerAngles.x;

        if (currentX > 180) currentX -= 360;

        float newX = Mathf.Lerp(currentX, targetRotationX, Time.deltaTime * rotationSpeed);

        transform.eulerAngles = new Vector3(newX, transform.eulerAngles.y, 0f);
    }

    
}