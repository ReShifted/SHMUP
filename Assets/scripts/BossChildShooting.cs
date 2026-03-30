using UnityEngine;
using System.Collections;

public class BossChildShooting : MonoBehaviour
{
    public GameObject bossbullet;
    public GameObject homingBullet; // assign your homing bullet prefab here

    private float[] angles = { 0f, 30f, 60f, 90f, 120f, 150f, 180f, 210f, 240f, 270f, 300f, 330f };

    public float shootCooldown = 2f;
    public float delayAfterParent = 0.5f;
    public float homingCooldown = 2f;

    private bool canShoot = true;

    void Start()
    {
        StartCoroutine(HomingRoutine()); // start homing loop
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
        Instantiate(homingBullet, transform.position, Quaternion.identity);
    }
}