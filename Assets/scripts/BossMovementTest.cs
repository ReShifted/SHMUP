using UnityEngine;
using System.Collections.Generic;

public class BossMovementTest : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float changeDirectionTime = 1f;
    public float smoothness = 3f;
    public float radius = 3f;
    public float edgeThreshold = 2f;
    public float centerInfluence = 2f;

    public List<Vector3> positionHistory = new List<Vector3>();
    public int maxHistory = 1000;

    private Vector2 currentDirection;
    private Vector2 targetDirection;
    private float timer;

    private Vector3 centerPosition;

    void Start()
    {
        centerPosition = transform.position;
        currentDirection = Random.insideUnitCircle.normalized;
        targetDirection = currentDirection;
    }

    void Update()
    {
        positionHistory.Insert(0, transform.position);

        if (positionHistory.Count > maxHistory)
        {
            positionHistory.RemoveAt(positionHistory.Count - 1);
        }

        timer += Time.deltaTime;

        if (timer >= changeDirectionTime)
        {
            targetDirection = Random.insideUnitCircle.normalized;
            timer = 0f;
        }

        Vector2 desiredDirection = targetDirection;

        float distance = Vector3.Distance(transform.position, centerPosition);

        if (distance > radius - edgeThreshold)
        {
            Vector2 toCenter = (centerPosition - transform.position).normalized;
            desiredDirection += toCenter * centerInfluence;
        }

        currentDirection = Vector2.Lerp(currentDirection, desiredDirection, smoothness * Time.deltaTime).normalized;

        Vector3 movement = new Vector3(currentDirection.x, currentDirection.y, 0f)
                           * moveSpeed * Time.deltaTime;

        transform.Translate(movement);

        Vector3 offset = transform.position - centerPosition;
        if (offset.magnitude > radius)
        {
            transform.position = centerPosition + offset.normalized * radius;
        }

        if (currentDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}