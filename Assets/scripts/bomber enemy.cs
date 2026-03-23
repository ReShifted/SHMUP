using UnityEngine;

public class bomberenemy : MonoBehaviour
{
    public float health = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x-0.01f, transform.position.y, transform.position.z);
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
