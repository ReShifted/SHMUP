//using System.Buffers;
//using System.Collections.Generic;
//using UnityEngine;

//public class backgrond_slide : MonoBehaviour
//{
//    public GameObject[] tiles; // Array of tile GameObjects to slide
//    private List<Vector3> alltiles = new List<Vector3>();
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
        
//    }
//    private void Awake()
//    {
//        // Initialize the tiles array with the child GameObjects of this GameObject
//        tiles = new GameObject[transform.childCount];
//        for (int i = 1; i < 4; i++)
//        {
//            int h = Random.Range(0, tiles.Length);
//            if (tiles[h] != null)
//            {
//                Instantiate(tiles[h],);
//                alltiles.Add(tiles[h].transform.position);
//            }
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
using System.Collections.Generic;
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

    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        SpawnInitialTiles();
    }

    void Update()
    {
        MoveTiles();
        CheckTiles();
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

        if (firstTile.transform.position.x <= leftDespawnX)
        {
            activeTiles.RemoveAt(0);
            Destroy(firstTile);

            GameObject lastTile = activeTiles[activeTiles.Count - 1];
            Vector3 newSpawnPos = new Vector3(lastTile.transform.position.x + tileWidth, -5f, 12.5f);
            if (Time.deltaTime < 45f)
            {
                GameObject newTile = SpawnRandomTile(newSpawnPos);
                activeTiles.Add(newTile);
            }
            else if (Time.deltaTime < 90f)
            {
                GameObject newTile = SpawnRandomwaistTile(newSpawnPos);
                activeTiles.Add(newTile);
            }
            else
            {
                GameObject newTile = SpawnRandommaxTile(newSpawnPos);
                activeTiles.Add(newTile);
            }
        }
    }
        GameObject SpawnRandomTile(Vector3 position)
        {
            int randomIndex = Random.Range(0, tilePrefabs.Length);
            return Instantiate(tilePrefabs[randomIndex], position, Quaternion.identity, transform);
        }
    GameObject SpawnRandomwaistTile(Vector3 position)
    {
        int randomIndex = Random.Range(0, tilePrefabs.Length);
        return Instantiate(waisttilePrefabs[randomIndex], position, Quaternion.identity, transform);
    }
    GameObject SpawnRandommaxTile(Vector3 position)
    {
        int randomIndex = Random.Range(0, tilePrefabs.Length);
        return Instantiate(maxtilePrefabs[randomIndex], position, Quaternion.identity, transform);
    }
}