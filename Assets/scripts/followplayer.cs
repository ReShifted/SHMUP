using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform player;

    public float tiltAmount = 1.5f;   // VERY small (0.5–2 is ideal)
    public float smoothSpeed = 3f;

    private Vector3 lastPlayerPosition;
    private Quaternion originalRotation;

    void Start()
    {
        lastPlayerPosition = player.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        Vector3 movement = player.position - lastPlayerPosition;

        // Convert movement into local direction (relative to world)
        float tiltX = -movement.z * tiltAmount; // forward/back tilt
        float tiltZ = movement.y * tiltAmount;  // sideways tilt

        Quaternion targetRotation = originalRotation * Quaternion.Euler(tiltX, 0f, tiltZ);

        // Smooth transition
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * smoothSpeed
        );

        lastPlayerPosition = player.position;
    }
}