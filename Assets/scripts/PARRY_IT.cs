using UnityEngine;

public class PARRY_IT : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            // Get the Rigidbody component of the bullet
            Rigidbody bulletRb = collision.gameObject.GetComponent<Rigidbody>();
            // Reverse the velocity of the bullet to parry it back
            if (bulletRb != null)
            {
                bulletRb.linearVelocity = -bulletRb.linearVelocity;
            }
        }
    }
}
