using UnityEngine;

public class PARRY_IT : MonoBehaviour
{
    public GameObject prefabToSpawn;

    [Range(0f, 1f)]
    public float spawnChance = 0.01f;

    void Start()
    {
        TrySpawn();
        Destroy(gameObject, 0.2f);
    }

    void TrySpawn()
    {
        if (Random.value <= spawnChance)
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);    
        }
    }
}