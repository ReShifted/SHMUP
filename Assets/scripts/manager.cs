using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public GameObject Enemy_Eye;
    public GameObject Enemy_Heli;
    public GameObject Enemy_Bomber;
    [SerializeField] public List<GameObject> AllEnemys = new List<GameObject>();
    public int wave = 0;
    private float spawncheck;
    private bool Spawn=false;
    private int spawn;
    public float spawnRate = 2;
    public float INITIAL_SPAWNRATE = 2f;
    public float MIN_SPAWNRATE = 0.1f;
    public float difficultyScale = 0.01f;
    private float currentSpawnRate;
    private float roundStart = 0;
    public float timer = 0;
    public float NextLevel;
    public bool stopspawns = false;


    void Start()
    {
        currentSpawnRate = INITIAL_SPAWNRATE;
        newwave();

        NextLevel=Time.deltaTime;

        roundStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        NextLevel = NextLevel+Time.deltaTime;
        HasMissingEntries();
        if (NextLevel>=135f)
        {
            stopspawns=true;
        }
        spawncheck = Random.Range(0, Time.deltaTime/100);
        if (spawncheck > spawncheck / 2) 
        { 
            Spawn = true; 
        }
        currentSpawnRate = INITIAL_SPAWNRATE - ((Time.time - roundStart) * difficultyScale);
        currentSpawnRate = Mathf.Max(currentSpawnRate, MIN_SPAWNRATE);

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            newwave();
            timer = 0;
        }

        if (NextLevel>=135f&&AllEnemys.Count<1)
        {
            SceneManager.LoadScene("Bobbie");
        }
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
        if (Spawn == true&&stopspawns==false)
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
            Spawn = true;
        }
    }
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