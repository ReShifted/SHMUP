using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform player;

    public float maxRotationX = 3f;
    public float smoothSpeed = 3f;

    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        float normalized = Mathf.Clamp(player.position.y / 6.1f, -1f, 1f);

        float rotationX = -normalized * maxRotationX;

        Quaternion targetRotation = originalRotation * Quaternion.Euler(rotationX, 0f, 0f);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * smoothSpeed
        );
    }
}