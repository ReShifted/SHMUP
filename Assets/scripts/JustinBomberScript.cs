using UnityEngine;

public class JustinBomberScript : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] Transform Player2;

    void Update()
    {
        MoveLeft();
        FollowPlayerY();
    }

    void MoveLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void FollowPlayerY()
    {
        if (Player2 == null) return;

        Vector3 target = transform.position;
        target.y = Player2.position.y;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("EnemyKiller"))
        {
            Destroy(gameObject);
        }
    }
}