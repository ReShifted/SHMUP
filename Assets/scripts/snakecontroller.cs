using UnityEngine;
using System.Collections.Generic;

public class snakecontroller : MonoBehaviour
{
    public float SnakeSpeed = 5f;
    public float SnakeRotationSpeed = 100f;
    public int gap = 10;

    public GameObject snakebody;
    public GameObject tailEnd;

    public float radius = 4f;

    private List<GameObject> bodyparts = new List<GameObject>();
    private List<Vector3> previousPositions = new List<Vector3>();

    private float steerTimer;
    private float currentTurn;
    private Vector3 centerPosition;

    void Start()
    {
        centerPosition = new Vector3(transform.position.x, transform.position.y, 0f);

        SnakesBody();
        SnakesBody();
        SnakesBody();
        SnakesBody();
        SnakesBody();
        SnakesBody();

        SnakesBody();

        GameObject tail = Instantiate(tailEnd, transform.position, Quaternion.identity);
        bodyparts.Add(tail);

        currentTurn = Random.Range(-0.3f, 0.3f);
    }

    void Update()
    {
        steerTimer += Time.deltaTime;

        if (steerTimer > 2f)
        {
            steerTimer = 0f;
            currentTurn = Random.Range(-0.3f, 0.3f);
        }

        transform.Rotate(Vector3.forward, currentTurn * SnakeRotationSpeed * Time.deltaTime);

        Vector3 direction = transform.up;
        direction = new Vector3(direction.x * 1.5f, direction.y * 0.5f, 0f).normalized;

        Vector3 newPosition = transform.position + direction * SnakeSpeed * Time.deltaTime;
        newPosition.z = 0f;
        transform.position = newPosition;

        Vector3 offset = transform.position - centerPosition;
        offset.z = 0f;

        if (offset.magnitude > radius)
        {
            offset = offset.normalized * radius;
            transform.position = new Vector3(centerPosition.x + offset.x, centerPosition.y + offset.y, 0f);

            Vector3 directionToCenter = (centerPosition - transform.position).normalized;
            float angle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        previousPositions.Insert(0, transform.position);

        int index = 0;
        foreach (var bodypart in bodyparts)
        {
            int posIndex = Mathf.Min(index * gap, previousPositions.Count - 1);
            Vector3 pos = previousPositions[posIndex];
            pos.z = 0f;
            bodypart.transform.position = pos;
            index++;
        }

        if (previousPositions.Count > 1000)
        {
            previousPositions.RemoveAt(previousPositions.Count - 1);
        }
    }

    private void SnakesBody()
    {
        GameObject newBodyPart = Instantiate(snakebody, transform.position, Quaternion.identity);
        bodyparts.Add(newBodyPart);
    }
}