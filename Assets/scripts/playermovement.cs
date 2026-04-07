using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float slowedSpeed = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? slowedSpeed : baseSpeed;

        float inputUpward = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) ? 1f : 0f;
        float inputDownward = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) ? 1f : 0f;
        float inputLeftward = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) ? 1f : 0f;
        float inputRightward = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) ? 1f : 0f;


        Vector3 move = Vector3.up * (inputUpward - inputDownward)
                     + transform.right * (inputRightward - inputLeftward);

        move = move.normalized;

        rb.linearVelocity = move * currentSpeed;
    }
}