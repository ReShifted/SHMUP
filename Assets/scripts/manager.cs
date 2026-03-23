using UnityEngine;
using System.Collections.Generic;

public class manager : MonoBehaviour
{
    public GameObject Enemy_Eye;
    public GameObject Enemy_Heli;
    [SerializeField] private List<GameObject> AllEnemys = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEyeEnemy();
        SpawnHeliEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnEyeEnemy()
    {
        Instantiate(Enemy_Eye, new Vector3(0, 0, 0), Quaternion.identity);
        AllEnemys.Add(Enemy_Eye);
    }
    public void SpawnHeliEnemy()
    {
        Instantiate(Enemy_Heli, new Vector3(0, 0, 0), Quaternion.identity);
        AllEnemys.Add(Enemy_Heli);
    }
}
