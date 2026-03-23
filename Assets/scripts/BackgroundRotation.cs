using UnityEngine;

public class BackgroundRotation : MonoBehaviour
{
    [Header("Rotation")]
    public float speed = 25f;

    [Header("References")]
    public Transform basePlate;
    public Transform spawnedContainer;

    [Header("Spawning")]
    public GameObject[] prefabs;
    public int spawnCount = 20;

    [Header("Spawn Area (Ring)")]
    public float innerRadius = 2f;
    public float outerRadius = 5f;

    [Header("Height Settings")]
    public float manualYOffset = 0.5f;
    public bool autoHeightFromCollider = true;

    void Start()
    {
        SpawnObjects();
    }

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    void SpawnObjects()
    {
        if (basePlate == null)
        {
            Debug.LogError("BasePlate not assigned!");
            return;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 dir = UnityEngine.Random.insideUnitCircle.normalized;

            float distance = UnityEngine.Random.Range(innerRadius, outerRadius);

            Vector2 point = dir * distance;

            Vector3 localPos = new Vector3(
                point.x / basePlate.localScale.x,
                0f,
                point.y / basePlate.localScale.z
            );

            Vector3 worldPos = basePlate.TransformPoint(localPos);

            GameObject prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Length)];

            float yOffset = manualYOffset;

            if (autoHeightFromCollider)
            {
                Collider col = prefab.GetComponent<Collider>();
                if (col != null)
                    yOffset = col.bounds.extents.y;
            }

            worldPos.y += yOffset;

            Instantiate(prefab, worldPos, Quaternion.identity, spawnedContainer);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (basePlate == null) return;

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(basePlate.position, outerRadius);

        Gizmos.DrawWireSphere(basePlate.position, innerRadius);
    }
}