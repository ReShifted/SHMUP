using UnityEngine;

public class playershoot : MonoBehaviour
{

    public GameObject BulletPrefab;
    public GameObject parryTHISSHIT;
    private float shieldlastFireTime = -2f;
    public float shieldfireCooldown = 2f;
    public float spreadshotcooldown = 2f;
    public float mainshotcooldown = 2f;
    public float mainshotlastFireTime = -2f;

    private float[] angles = {15f,0f,-15f};

    void Start()
    {
        
    }

    void Update()
    {
        // Shoot with space key
        if (Time.time >= mainshotlastFireTime + mainshotcooldown)
        {
            mainshotlastFireTime = Time.time;
        
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        }

        // parry with E key
        if (Input.GetKeyDown(KeyCode.E)&& Time.time >= shieldlastFireTime + shieldfireCooldown)
        {
            shieldlastFireTime = Time.time;
            Instantiate(parryTHISSHIT, transform.position, Quaternion.identity);
        }

        // Spread shot with Q key
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= shieldlastFireTime + spreadshotcooldown)
        {
            shieldlastFireTime = Time.time;
            foreach (float angle in angles)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, angle);
                Instantiate(BulletPrefab, transform.position, rotation);
            }
        }
    }
}



   
   
