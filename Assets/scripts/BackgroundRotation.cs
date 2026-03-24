using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PrefabSettings
{
    public GameObject prefab;

    [Header("Per-Prefab Fixes")]
    public Vector3 rotationOffset;
    public float scaleMultiplier = 1f;
}

public class BackgroundRotation : MonoBehaviour
{
    [Header("Rotation")]
    public float speed = 25f;

    [Header("References")]
    public Transform basePlate;
    public Transform spawnedContainer;

    [Header("Spawning")]
    public PrefabSettings[] prefabs;
    public int spawnCount = 20;

    [Header("Spawn Area (Ring)")]
    public float innerRadius = 2f;
    public float outerRadius = 5f;

    [Header("Height")]
    public float manualYOffset = 0.5f;

    [Header("Spacing")]
    public float minDistanceBetweenBuildings = 1.5f;
    public int maxAttemptsPerObject = 20;

    private List<Vector3> spawnedPositions = new List<Vector3>();

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

        if (prefabs.Length == 0)
        {
            Debug.LogError("No prefabs assigned!");
            return;
        }

        spawnedPositions.Clear();

        for (int i = 0; i < spawnCount; i++)
        {
            bool placed = false;

            for (int attempt = 0; attempt < maxAttemptsPerObject; attempt++)
            {
                Vector2 dir = Random.insideUnitCircle.normalized;
                float distance = Random.Range(innerRadius, outerRadius);
                Vector2 point = dir * distance;

                Vector3 localPos = new Vector3(
                    point.x / basePlate.localScale.x,
                    0f,
                    point.y / basePlate.localScale.z
                );

                Vector3 worldPos = basePlate.TransformPoint(localPos);
                worldPos.y += manualYOffset;

                // --- SPACING CHECK ---
                bool tooClose = false;
                foreach (Vector3 pos in spawnedPositions)
                {
                    if (Vector3.Distance(pos, worldPos) < minDistanceBetweenBuildings)
                    {
                        tooClose = true;
                        break;
                    }
                }

                if (tooClose) continue;

                PrefabSettings settings = prefabs[Random.Range(0, prefabs.Length)];
                if (settings.prefab == null) continue;

                // --- ROTATION: FACE OUTWARD ---
                Vector3 outwardDir = (worldPos - basePlate.position).normalized;
                outwardDir.y = 0f;

                if (outwardDir == Vector3.zero)
                    outwardDir = Vector3.forward;

                Quaternion faceOutward = Quaternion.LookRotation(outwardDir, Vector3.up);

                // --- PER PREFAB ROTATION FIX ---
                Quaternion modelFix = Quaternion.Euler(settings.rotationOffset);

                Quaternion finalRot = faceOutward * modelFix;

                GameObject obj = Instantiate(settings.prefab, worldPos, finalRot, spawnedContainer);

                // --- SCALE ---
                obj.transform.localScale *= settings.scaleMultiplier;

                spawnedPositions.Add(worldPos);
                placed = true;
                break;
            }

            if (!placed)
            {
                Debug.LogWarning("Could not place object without overlap.");
            }
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