using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heli : MonoBehaviour
{
    // timer for movement (seconds)
    float timer = 0f;
    // duration to move on x axis
    public float moveDuration = 5f;
    public float speed = 1f;


    [Header("Heli stats")]
    //[space]
    private Rigidbody helirb;
    public Rigidbody heliprojectile;
    public GameObject heliprojectilerotation;//later this changed so this is now gameobject as a whole and not just the rotation of the projectile
    private float helilastFireTime = -2f;
    [Tooltip("This var changes the fire cooldown of the heli")]
    public float helifireCooldown = 2f;

    public float health= 100f;

    // start and target x positions
    private float startX;
    public float targetX = -6f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        helirb = GetComponent<Rigidbody>();
        startX = transform.position.x;
        timer = 0f;
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

        // Move only the x position over moveDuration seconds
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