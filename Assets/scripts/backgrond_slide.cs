using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class backgrond_slide : MonoBehaviour
{
    [Header("Tile setup")]
    public GameObject[] tilePrefabs;   // Random tiles to choose from
    public GameObject[] waisttilePrefabs;
    public GameObject[] maxtilePrefabs;
    public int initialTileCount = 5;
    public float tileWidth = 10f;      // Width of one tile
    [Header("Movement")]
    public float moveSpeed = 2f;
    [Header("Despawn / Spawn")]
    public float leftDespawnX = -200f;  // If tile goes past this, remove it
    public float spawnX = 15f;         // New tile spawns here on the right
    public List<GameObject> activeTiles = new List<GameObject>();
    public float timed;
    private void Awake()
    {
        timed = Time.deltaTime;
    }
    void Start()
    {
        SpawnInitialTiles();
    }

    void Update()
    {
        timed=timed+Time.deltaTime;
        MoveTiles();
        CheckTiles();
        //if (activeTiles.Count<5)
        //{
        //    Debug.Log("addtile");
        //    addtilemax();
        //}
    }

    void SpawnInitialTiles()
    {
        initialTileCount += 1;
        for (int i = 1; i < initialTileCount; i++)
        {
            Vector3 spawnPos = new Vector3((spawnX + i * tileWidth) - 120f, -5f, 12.5f);
            GameObject tile = SpawnRandomTile(spawnPos);
            activeTiles.Add(tile);
        }
    }

    void MoveTiles()
    {
        foreach (GameObject tile in activeTiles)
        {
            tile.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }

    void CheckTiles()
    {
        if (activeTiles.Count == 0) return;

        GameObject firstTile = activeTiles[0];

        if (firstTile.transform.position.x <= leftDespawnX || activeTiles.Count<initialTileCount)
        {
            activeTiles.RemoveAt(0);
            Destroy(firstTile);

            GameObject lastTile = activeTiles[activeTiles.Count-1];
            Vector3 newSpawnPos = new Vector3(lastTile.transform.position.x + tileWidth, -5f, 12.5f);
            if (timed < 25f)
            {
                GameObject newTile = SpawnRandomTile(newSpawnPos);
                activeTiles.Add(newTile);
            }
            else if (timed < 70f)
            {
                GameObject newTile = SpawnRandomwaistTile(newSpawnPos);
                activeTiles.Add(newTile);
            }
            else if(timed >= 70f)
            {
                GameObject newTile = SpawnRandommaxTile(newSpawnPos);
                activeTiles.Add(newTile);
            }
        }
    }
    //private void addtilemax()
    //{
    //    GameObject lastTile = activeTiles[activeTiles.Count];
    //    Vector3 newSpawnPos = new Vector3(lastTile.transform.position.x + tileWidth, -5f, 12.5f);
    //    if (timed < 25f)
    //    {
    //        GameObject newTile = SpawnRandomTile(newSpawnPos);
    //        activeTiles.Add(newTile);
    //    }
    //    else if (timed < 70f)
    //    {
    //        GameObject newTile = SpawnRandomwaistTile(newSpawnPos);
    //        activeTiles.Add(newTile);
    //    }
    //    else if (timed >= 70f)
    //    {
    //        GameObject newTile = SpawnRandommaxTile(newSpawnPos);
    //        activeTiles.Add(newTile);
    //    }
    //}
    GameObject SpawnRandomTile(Vector3 position)
        {
            int randomIndex = Random.Range(1, tilePrefabs.Length);
            return Instantiate(tilePrefabs[randomIndex], position, Quaternion.identity, transform);
        }
    GameObject SpawnRandomwaistTile(Vector3 position)
    {
        int randomIndex = Random.Range(1, tilePrefabs.Length);
        return Instantiate(waisttilePrefabs[randomIndex], position, Quaternion.identity, transform);
    }
    GameObject SpawnRandommaxTile(Vector3 position)
    {
        int randomIndex = Random.Range(1, tilePrefabs.Length);
        return Instantiate(maxtilePrefabs[randomIndex], position, Quaternion.identity, transform);
    }
}