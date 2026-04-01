using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed = 25f;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float inputUpward = Input.GetKey(KeyCode.W) ? 2f : 0f;
        float inputDownward = Input.GetKey(KeyCode.S) ? 2f : 0f;
        float inputLeftward = Input.GetKey(KeyCode.A) ? 2f : 0f;
        float inputRightward = Input.GetKey(KeyCode.D) ? 2f : 0f;

        Vector3 move = transform.up * (inputUpward - inputDownward)
                     + transform.right * (inputRightward - inputLeftward);

        rb.linearVelocity = move * speed;

    }
}