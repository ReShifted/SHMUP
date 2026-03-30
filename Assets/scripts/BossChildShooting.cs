using UnityEngine;
using System.Collections;

public class BossChildShooting : MonoBehaviour
{
    public GameObject bossbullet;
    public GameObject homingBullet;

    private float[] angles = { 0f, 30f, 60f, 90f, 120f, 150f, 180f, 210f, 240f, 270f, 300f, 330f };

    public float shootCooldown = 2f;
    public float delayAfterParent = 0.5f;
    public float homingCooldown = 4f;

    private bool canShoot = true;

    void Start()
    {
        StartCoroutine(HomingRoutine());
    }

    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        canShoot = false;

        yield return new WaitForSeconds(delayAfterParent);

        Shoot360();

        yield return new WaitForSeconds(shootCooldown);

        canShoot = true;
    }

    IEnumerator HomingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(homingCooldown);

            ShootHoming();
        }
    }

    void Shoot360()
    {
        foreach (float angle in angles)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Instantiate(bossbullet, transform.position, rotation);
        }
    }

    void ShootHoming()
    {
        foreach (float angle in angles)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(homingBullet, transform.position, rotation);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 dir = rotation * Vector3.right;
                rb.linearVelocity = dir * 2f;
            }
        }
    }
}