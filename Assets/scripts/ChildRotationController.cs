using UnityEngine;

public class ChildRotationController : MonoBehaviour
{
    public Transform target;
    private Vector3 lastPosition;

    void Start()
    {
        if (target != null)
            lastPosition = target.position;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 movement = target.position - lastPosition;

        Vector3 currentEuler = transform.localEulerAngles;

        if (movement.x > 0.01f)
        {
            transform.localRotation = Quaternion.Euler(0f, -90f, 90f);
        }
        else if (movement.x < -0.01f)
        {
            transform.localRotation = Quaternion.Euler(180f,-90f,90f);
        }

        lastPosition = target.position;
    }
}