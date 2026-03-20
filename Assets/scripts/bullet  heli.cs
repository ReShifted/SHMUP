using UnityEngine;
using UnityEngine.UIElements;

public class bulletheli : MonoBehaviour
{
    private float angle;
    private float spread;
    private Quaternion bulletRotation;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        angle = Mathf.Atan2(0, 20) * Mathf.Rad2Deg;
        spread = Random.Range(-10, 10);
        bulletRotation = Quaternion.Euler(new Vector3(angle + spread,0,0));

        transform.rotation = bulletRotation;
        rb.linearVelocity = bulletRotation * Vector3.forward;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PARRYIT"))
        {
            rb.linearVelocity = -rb.linearVelocity;
        }
    }
}
