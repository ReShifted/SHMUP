using UnityEngine;

public class bomberenemy : MonoBehaviour
{
    public float health = 200f;
    public manager Manager;

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x-0.01f, transform.position.y, transform.position.z);


        Destroy(gameObject, 4f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 10f;
            if (health <= 0f)
            {
                Manager.AllEnemys.Remove(gameObject);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("EnemyKiller"))
        {
            Manager.AllEnemys.Remove(gameObject);
            Destroy(gameObject);
            }
    }
}
