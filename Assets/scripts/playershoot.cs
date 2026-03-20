using UnityEngine;

public class playershoot : MonoBehaviour
{

    public GameObject BulletPrefab;
    public GameObject parryTHISSHIT;
    private float shieldlastFireTime = -2f;
    public float shieldfireCooldown = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.E)&& Time.time >= shieldlastFireTime + shieldfireCooldown)
        {
            shieldlastFireTime = Time.time;
            Instantiate(parryTHISSHIT, transform.position, Quaternion.identity);
        }
    }
}



   
   
