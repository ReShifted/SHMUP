using UnityEngine;

public class eye : MonoBehaviour
{
    private Rigidbody Eyerb;
    public GameObject Eyeprojectile;
    private float EyelastFireTime = -2f;
    private float EyefireCooldown = 2f;
    private float health = 100f;

    private float startX;
    public float targetX = -6f;
    float timer = 0f;
    public float moveDuration = 5f;
    public float speed = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Eyerb = GetComponent<Rigidbody>();
        startX = transform.position.x;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= EyelastFireTime + EyefireCooldown)
        {
            EyelastFireTime = Time.time;
            Instantiate(Eyeprojectile,transform.position,transform.rotation);
        }

        if (timer < moveDuration)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / moveDuration);
            float newX = Mathf.Lerp(startX, targetX, progress);

            Vector3 pos = transform.position;
            pos.x = newX;
            transform.position = pos;
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

