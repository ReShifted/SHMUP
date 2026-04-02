using UnityEngine;

public class playershoot : MonoBehaviour
{

    public GameObject BulletPrefab;
    public GameObject parryTHISSHIT;
    private float shieldlastFireTime = -2f;
    public float shieldfireCooldown = 2f;
    public float spreadshotcooldown = 0.3f;
    private float extraSpreadshotCooldown = 1f;

    private float LastBulletFireTime = 0f;
    public float bulletFireRate = 0.25f;

    private float[] angles = {30f,15f,0f,-15f,-30f};

    void Start()
    {
        
    }

    void Update()
    {
        // Shoot with space key
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        //}

        // parry with E key
        if (Input.GetKeyDown(KeyCode.E)&& Time.time >= shieldlastFireTime + shieldfireCooldown)
        {
            shieldlastFireTime = Time.time;
            Instantiate(parryTHISSHIT, transform.position, Quaternion.identity);
        }

        // Spread shot with Q key
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= extraSpreadshotCooldown + spreadshotcooldown)
        {
            extraSpreadshotCooldown = Time.time;
            foreach (float angle in angles)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, angle);
                Instantiate(BulletPrefab, transform.position, rotation);
            }
        }

        //spawns bullet every 0.2 seconds
        if (Time.time >= LastBulletFireTime + bulletFireRate&& Input.GetKey(KeyCode.Space))
        {
            LastBulletFireTime = Time.time;
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        } 
    }
    
}



   
   
