using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    public enum ObjectType { Enemy, SmallEnemy, BigEnemy};
   
    public Tilemap Road;
    public GameObject[] Spawned; //0 - enemy, 1 - small, 2 - big

    //Note to self: Rate is too fast, pls change it.
    public float BigEnemyProbability = 0.2f; //20% chance
    public float EnemyProbability = 0.1f;

    private List<Vector3> validSpawnPoints = new List<Vector3>();
    private List<GameObject> spawnEnemies = new List<GameObject>(); // Only have 1 enemy

    //Variables for Checking
    private bool isSpawning = false;
    public float Cooldown = 0.5f;
    public int maxObjects = 5; //Limit of Enemy Appearances

    /************************************************************
    
    ======= Version 1.0 (m/d/y, 08/04/2025) ========
    FEATURES
    ================================================
    - Added 2 more object Types in enum.
    - Changed gameObject needing a Sprite Renderer to having the enemy Spawn on a TileMap, Less hassle on handling the spawn points.
    
    Author: Dani
    ************************************************************/


    void Start()
    {
        ValidCells();
        StartCoroutine(SpawnObjectsifNeeded());
    }

    void Update()
    {
        if(!isSpawning && ActiveObjectCount() < maxObjects)
        {
            StartCoroutine(SpawnObjectsifNeeded());
        }
    }

    private int ActiveObjectCount()
    {
        spawnEnemies.RemoveAll(item => item == null);
        return spawnEnemies.Count;
    }

    private IEnumerator SpawnObjectsifNeeded()
    {
        isSpawning = true;

        while (ActiveObjectCount() < maxObjects)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Cooldown);
        }
        
        isSpawning = false;
    }

    // Check if there is an enemy in this position
    private bool PosHasEnemy(Vector3 positionToCheck)
    {
        return spawnEnemies.Any(checkObj => checkObj && Vector3.Distance(checkObj.transform.position, positionToCheck) < 1.0f); //Checking Every pass of unit
    }

    private ObjectType RandomObjectType()
    {
        float randomChoice = Random.value;
        if(randomChoice <= EnemyProbability)
        {
            return ObjectType.Enemy;
        }
        else if(randomChoice <= (EnemyProbability + BigEnemyProbability))
        {
            return ObjectType.BigEnemy;
        }
        else
        {
            return ObjectType.SmallEnemy;
        }

    }

    private void SpawnEnemy()
    {
        if (validSpawnPoints.Count == 0) return;

        Vector3 spawnPos = Vector3.zero;
        bool validPosfound = false;

        while(!validPosfound && validSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, validSpawnPoints.Count);
            Vector3 potentialPos = validSpawnPoints[randomIndex];
            Vector3 leftPos = potentialPos + Vector3.left;
            Vector3 rightPos = potentialPos + Vector3.right;

            if(!PosHasEnemy(leftPos) && !PosHasEnemy(rightPos))
            {
                spawnPos = potentialPos;
                validPosfound = true;
            }
            validSpawnPoints.RemoveAt(randomIndex);
        }

        if (validPosfound)
        {
            ObjectType objectType = RandomObjectType();
            GameObject gameObject = Instantiate(Spawned[(int)objectType], spawnPos, Quaternion.identity);
            spawnEnemies.Add(gameObject);

            //Enemy Destroyed on their after a set time
            if(objectType != ObjectType.Enemy)
            {
                StartCoroutine(DestroyObjectsAfterTime(gameObject, Cooldown));
            }
        }
    }

    private IEnumerator DestroyObjectsAfterTime(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);

        if (gameObject)
        {
            spawnEnemies.Remove(gameObject);
            validSpawnPoints.Add(gameObject.transform.position);
            Destroy(gameObject);
        }
    }

    private void ValidCells()
    {
        validSpawnPoints.Clear();//every start map is cleared
        BoundsInt boundsInt = Road.cellBounds;
        TileBase[] allTiles = Road.GetTilesBlock(boundsInt);
        Vector3 start = Road.CellToWorld(new Vector3Int(boundsInt.xMin, boundsInt.yMin, 0));

        //Checks which cells are valid to spawn
        for (int x = 0; x < boundsInt.size.x; x++)
        {
            for (int y = 0; y < boundsInt.size.y; y++)
            {
                TileBase tile = allTiles[x + y * boundsInt.size.x];
                if(tile != null)
                {
                    Vector3 place = start + new Vector3(x + 0.5f, y + 2f, 0);
                    validSpawnPoints.Add(place);
                }
            }
        }
    }
}
