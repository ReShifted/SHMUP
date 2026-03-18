using UnityEngine;
using System.Collections.Generic;

public class manager : MonoBehaviour
{
    public GameObject Enemy_Eye;
    [SerializeField] private List<GameObject> AllEnemys = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnEnemy()
    {
        Instantiate(Enemy_Eye, new Vector3(0, 0, 0), Quaternion.identity);
        AllEnemys.Add(Enemy_Eye);
    }
}
