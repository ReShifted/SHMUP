using UnityEngine;
using System.Collections.Generic;

public class manager : MonoBehaviour
{
    public GameObject Enemy_Eye;
    public GameObject Enemy_Heli;
    public GameObject Enemy_Bomber;
    [SerializeField] public List<GameObject> AllEnemys = new List<GameObject>();
    public int wave = 0;
    private float spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newwave();
    }

    // Update is called once per frame
    void Update()
    {
        HasMissingEntries();
        newwave();
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
            wave += 1;
            for (int i = 0; i < wave * 2 + 1; i++)
            {
                spawn = Random.Range(0, 3);
                if (spawn == 0)
                {
                    SpawnEyeEnemy();
                }
                else if (spawn == 1)
                {
                    SpawnHeliEnemy();
                }
                else
                {
                    SpawnBomberEnemy();
                }
            }
        } }
            public bool HasMissingEntries()
    {
        for (int i = 0; i < AllEnemys.Count; i++)
        {
            if (AllEnemys[i] == null) //als de asteroid is vernietigd
            {
                AllEnemys.RemoveAt(i); //haal hem dan uit de lijst
                return true;
            }
        }
        return false;
    }
}

    //public void DamagePlayer(playerHP player)
    //{
    //    if (player != null)
    //    {
    //        player.TakeDamage(damage);
    //        Debug.Log("Player took " + damage + " damage!");
    //    }
    //}

