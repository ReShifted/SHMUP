using UnityEngine;
using System.Collections;

public class BossChildShooting : MonoBehaviour
{
    public GameObject bossbullet; // normal bullet
    public GameObject homingBullet; // homing bullet

    private float[] angles = { 0f, 30f, 60f, 90f, 120f, 150f, 180f, 210f, 240f, 270f, 300f, 330f }; // bullet directions

    public float shootCooldown = 2f; // time between normal shots
    public float delayAfterParent = 0.5f; // delay after parent shot
    public float homingCooldown = 4f; // time between homing shots

    private bool canShoot = true; // can shoot normal bullets

    void Start()
    {
        StartCoroutine(HomingRoutine()); // start homing bullets loop
    }

    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(ShootRoutine()); // start normal shot routine
        }
    }

    IEnumerator ShootRoutine()
    {
        canShoot = false; // prevent multiple shots at once

        yield return new WaitForSeconds(delayAfterParent); // wait a bit

        Shoot360(); // shoot all around

        yield return new WaitForSeconds(shootCooldown); // wait cooldown

        canShoot = true; // allow shooting again
    }

    IEnumerator HomingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(homingCooldown); // wait cooldown

            ShootHoming(); // shoot homing bullets
        }
    }

    void Shoot360()
    {
        foreach (float angle in angles)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle); // set bullet angle
            Instantiate(bossbullet, transform.position, rotation); // create bullet
        }
    }

    void ShootHoming()
    {
        foreach (float angle in angles)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle); // set bullet angle
            GameObject bullet = Instantiate(homingBullet, transform.position, rotation); // create bullet

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 dir = rotation * Vector3.right;
                rb.linearVelocity = dir * 2f; // set bullet speed
            }
        }
    }
}