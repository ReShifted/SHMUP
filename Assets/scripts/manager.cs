using UnityEngine;
using System.Collections.Generic;

public class manager : MonoBehaviour
{
    public GameObject Enemy_Eye;
    public GameObject Enemy_Heli;
    public GameObject Enemy_Bomber;
    [SerializeField] private List<GameObject> AllEnemys = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEyeEnemy();
        SpawnHeliEnemy();
        SpawnBomberEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnEyeEnemy()
    {
        Instantiate(Enemy_Eye, new Vector3(11,Random.Range(-4,6),  0), Quaternion.identity);
        AllEnemys.Add(Enemy_Eye);
    }
    public void SpawnHeliEnemy()
    {
        Instantiate(Enemy_Heli, new Vector3(11, Random.Range(-4, 6), 0), Quaternion.identity);
        AllEnemys.Add(Enemy_Heli);
    }
    public void SpawnBomberEnemy()
    {
        Instantiate(Enemy_Bomber, new Vector3(11, Random.Range(-4, 6), 0), Quaternion.identity);
        AllEnemys.Add(Enemy_Bomber);
    }
}
