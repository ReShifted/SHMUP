using UnityEngine;

public class bossbullet : MonoBehaviour
{
        public float speed = 10f;
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.linearVelocity = transform.right * speed;

        Destroy(gameObject, 3f);
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
