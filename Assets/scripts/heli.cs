using UnityEngine;
using System.Collections;
using System.Linq;

public class heli : MonoBehaviour
{

    [Header("Heli stats")]
    //[space]
    private Rigidbody helirb;
    public Rigidbody heliprojectile;
    public GameObject heliprojectilerotation;
    private float helilastFireTime = -2f;
    [Tooltip("This var changes the fire cooldown of the heli")]
    public float helifireCooldown = 2f;


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
              //  Destroy(, 5.0f);
            }
        }
    }
}