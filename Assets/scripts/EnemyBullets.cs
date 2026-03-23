using UnityEngine;

public class EnemyBullets : MonoBehaviour
{

    public float speed = 20f;

    // Update is called once per frame
    void Update()
    {
        //moves the bullet forward
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        //destroys the bullet after 3 seconds
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // checks if the collided object has the tag Player
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
