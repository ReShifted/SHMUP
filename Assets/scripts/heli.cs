using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heli : MonoBehaviour
{
    [SerializeField] Transform endPoint;
    [SerializeField] Transform startPoint;
    [SerializeField] float travelTime;
    [SerializeField] bool doMovement;
    [Header("Heli stats")]
    //[space]
    private Rigidbody helirb;
    public Rigidbody heliprojectile;
    public GameObject heliprojectilerotation;//later this changed so this is now gameobject as a whole and not just the rotation of the projectile
    private float helilastFireTime = -2f;
    [Tooltip("This var changes the fire cooldown of the heli")]
    public float helifireCooldown = 2f;

    private float health= 100f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        helirb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= helilastFireTime + helifireCooldown)
        {
            helilastFireTime = Time.time;
            for (int i = 0; i < 5; i++)
            {
                Instantiate(heliprojectilerotation, transform.position, transform.rotation);
               // Destroy(heliprojectilerotation,5.0f);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 10f;
            if (health <= 0f)
            {
                DestroyImmediate(gameObject,true);
            }
        }
    }
    void TravelFinished()
    {
        doMovement = false;
        Debug.Log("KLAAR!");
        SceneManager.LoadScene("SampleScene");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        startPoint = player.gameObject.transform;
        //endPoint.position = new Vector3(endPoint.position.x, endPoint.position.y, startPoint.position.z);
        timer = 0f;
        doMovement = true;
        rb.linearVelocity = Vector3.zero;
    }
}
}