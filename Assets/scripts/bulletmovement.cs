using UnityEngine;

public class bulletmovement : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PARRYIT"))
        {
            speed += 5;
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}