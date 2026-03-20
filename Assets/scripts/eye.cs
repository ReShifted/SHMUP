using UnityEngine;

public class eye : MonoBehaviour
{
    private Rigidbody Eyerb;
    public Rigidbody Eyeprojectile;
    private float EyelastFireTime = -2f;
    private float EyefireCooldown = 2f;
    private float health = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Eyerb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= EyelastFireTime + EyefireCooldown)
        {
            EyelastFireTime = Time.time;

            Rigidbody clone = Instantiate(Eyeprojectile, transform.position, transform.rotation);
            clone.linearVelocity = transform.TransformDirection(Vector3.forward * 20);
            Destroy(clone.gameObject, 5.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 10f;
            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}

