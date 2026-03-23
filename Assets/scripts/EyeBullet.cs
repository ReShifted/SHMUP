using UnityEngine;

public class EyeBullet : MonoBehaviour
{
    public TimeManager Timemanager;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timemanager = FindAnyObjectByType<TimeManager>();
        rb.linearVelocity = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 20f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PARRYIT"))
        {
            rb.linearVelocity = -rb.linearVelocity*2;

            Timemanager.DoSlowmotion();
        }
    }
    
}
