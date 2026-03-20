using UnityEngine;

public class bulletmovement : MonoBehaviour
{

    public float speed = 20f;
    void Update()
    {
        //moves the bullet forward
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        //destroys the bullet after 3 seconds
        Destroy (gameObject, 3f);
    }
}
