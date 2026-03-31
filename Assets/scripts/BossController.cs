using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public GameObject bossbullet;

    public Transform[] children; // assign all child shooting points

    private float[] angles = { 0f, 30f, 60f, 90f, 120f, 150f, 180f, 210f, 240f, 270f, 300f, 330f };

    public float shootInterval = 5f;
    public float delayBetweenChildren = 0.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            timer = 0f;
            StartCoroutine(ShootSequence());
        }
    }

    IEnumerator ShootSequence()
    {
        foreach (Transform child in children)
        {
            Shoot360(child.position);
            yield return new WaitForSeconds(delayBetweenChildren);
        }
    }

    void Shoot360(Vector3 position)
    {
        foreach (float angle in angles)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Instantiate(bossbullet, position, rotation);
          
        }
    }
}