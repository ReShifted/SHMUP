using UnityEngine;

public class bomberenemy : MonoBehaviour
{
    public float health = 100f;
    public manager Manager;
    public feulmeter Feulmeter; // assign in Inspector OR

    void Start()
    {
        if (Feulmeter == null)
        {
           // Feulmeter = FindObjectOfType<feulmeter>();
            // or
             var img = GameObject.Find("Canvas/Image (1)/Image (2)");
             if (img != null) Feulmeter = img.GetComponent<feulmeter>();
        }
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
                Feulmeter.feulup();
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
