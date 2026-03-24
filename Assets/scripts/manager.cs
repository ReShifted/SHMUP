using UnityEngine;
using System.Collections.Generic;

public class manager : MonoBehaviour
{
    public GameObject Enemy_Eye;
    public GameObject Enemy_Heli;
    public GameObject Enemy_Bomber;
    [SerializeField] public List<GameObject> AllEnemys = new List<GameObject>();

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
        GameObject eyeenemy = Instantiate(Enemy_Eye, new Vector3(11,Random.Range(-4,6),  0), Quaternion.identity) as GameObject;
        AllEnemys.Add(eyeenemy);
    }
    public void SpawnHeliEnemy()
    {
        GameObject helienemy = Instantiate(Enemy_Heli, new Vector3(11, Random.Range(-4, 6), 0), Quaternion.identity) as GameObject;
        AllEnemys.Add(helienemy);
    }
    public void SpawnBomberEnemy()
    {
        GameObject nukeenemy = Instantiate(Enemy_Bomber, new Vector3(11, Random.Range(-4, 6), 0), Quaternion.identity) as GameObject;
        AllEnemys.Add(nukeenemy);
    }
    public void newwave()
    {
        if (AllEnemys.Count == 0)
        {
            SpawnEyeEnemy();
            SpawnHeliEnemy();
            SpawnBomberEnemy();
        }
    }
}
