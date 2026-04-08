using UnityEngine;
using System.Collections.Generic;

public class snakecontroller : MonoBehaviour
{
    public float SnakeSpeed = 5f;
    public float SnakeRotationSpeed = 100f;
    public int gap = 10;

    public GameObject snakebody;
    public GameObject tailEnd;

    public float radius = 4f; // limit distance from center

    private List<GameObject> bodyparts = new List<GameObject>();
    private List<Vector3> previousPositions = new List<Vector3>();
    private List<Quaternion> previousRotations = new List<Quaternion>();

    private float steerTimer;
    private float currentTurn;
    private Vector3 centerPosition;
    private float fixedZ = -14.64f; // fixed z-axis position

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, fixedZ);
        centerPosition = new Vector3(transform.position.x, transform.position.y, fixedZ);

        for (int i = 0; i < 7; i++)
            SnakesBody(); // create initial snake body parts

        GameObject tail = Instantiate(tailEnd, transform.position, transform.rotation);
        tail.transform.parent = transform;
        bodyparts.Add(tail); // add tail

        currentTurn = Random.Range(-0.3f, 0.3f); // initial random turn
    }

    void Update()
    {
        steerTimer += Time.deltaTime;

        if (steerTimer > 2f)
        {
            steerTimer = 0f;
            currentTurn = Random.Range(-0.3f, 0.3f); // change turn randomly
        }

        transform.Rotate(Vector3.forward, currentTurn * SnakeRotationSpeed * Time.deltaTime);

        Vector3 direction = transform.up;
        direction = new Vector3(direction.x * 1.5f, direction.y * 0.5f, 0f).normalized; // adjust movement

        Vector3 newPosition = transform.position + direction * SnakeSpeed * Time.deltaTime;
        newPosition.z = fixedZ;

        // keep snake within radius from center
        Vector3 offset = newPosition - centerPosition;
        offset.z = 0f;

        if (offset.magnitude > radius)
        {
            offset = offset.normalized * radius;
            newPosition = new Vector3(centerPosition.x + offset.x, centerPosition.y + offset.y, fixedZ);

            Vector3 directionToCenter = (centerPosition - transform.position).normalized;
            float angle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle); // rotate towards center
        }

        transform.position = newPosition;

        // store positions and rotations for body parts
        previousPositions.Insert(0, transform.position);
        previousRotations.Insert(0, transform.rotation);

        int index = 0;
        foreach (var bodypart in bodyparts)
        {
            int posIndex = Mathf.Min(index * gap, previousPositions.Count - 1);
            bodypart.transform.position = previousPositions[posIndex]; // follow head
            bodypart.transform.rotation = previousRotations[posIndex];
            index++;
        }

        // limit stored positions to save memory
        if (previousPositions.Count > 1000)
        {
            previousPositions.RemoveAt(previousPositions.Count - 1);
            previousRotations.RemoveAt(previousRotations.Count - 1);
        }
    }

    private void SnakesBody()
    {
        GameObject newBodyPart = Instantiate(snakebody, transform.position, transform.rotation);
        newBodyPart.transform.parent = transform;
        bodyparts.Add(newBodyPart); // add new body part
    }
}