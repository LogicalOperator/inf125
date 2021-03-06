using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;


public class boardManager : MonoBehaviour
{
    [Serializable]
    // wrapper class used by boardManager
    public class Count
    {
        public int minimum;
        public int maximum;


        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    // columns and rows are public so we can change them via inspector
    public int columns = 20;
    public int rows = 20;
    public Count wallCount = new Count(5, 9);                       // Lower and upper limit for our random number of walls per level
    //public GameObject exit;                                       // Prefab to spawn for exit
    public GameObject[] floorTiles;                                 // Array of floor prefabs
    public GameObject[] wallTiles;                                  // Array of wall prefabs
    public GameObject[] enemyTiles;                                 // Array of enemy prefabs
    public GameObject[] outerWallTiles;                             // Array of outer tile prefabs
    public Vector3[] spawnLocs;                                     // Enemy respawn locations

    private Transform holder;                                       // Stores a reference to information about the transform column in the inspector
    private List<Vector3> gridPositions = new List<Vector3>();      // Locations to place tiles

    void initializeList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                // Add new vector containing position information
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }


    // setup background and managerGameObject
    void boardSetup()
    {
        holder = new GameObject("Board").transform;
        // Go through and set floor and outerwall tiles
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject inst = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                    inst = outerWallTiles[Random.Range(0, outerWallTiles.Length)]; // add outer wall to edge of board
                // Instantiate tile to grid and cast to GameObject
                GameObject instance = Instantiate(inst, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(holder);
            }
        }
    }


    // returns a random position from gridPositions
    Vector3 randomPosition()
    {
        int index = Random.Range(0, gridPositions.Count);
        Vector3 pos = gridPositions[index];
        gridPositions.RemoveAt(index); // removes random number so it isn't generated again
        return pos;
    }

    // takes in an array of GameObjects, and a range for the number of objects to create
    void layoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objCount = Random.Range(minimum, maximum + 1);
        for (int i = 0; i < objCount; i++)
        {
            Vector3 rp = randomPosition(); // get random position from gridPosition
            GameObject choice = tileArray[Random.Range(0, tileArray.Length)]; // choose random tile
            Instantiate(choice, rp, Quaternion.identity);
        }
    }


    // initializes scene, calls setup functions to create the level passed in
    public void setupScene(int level)
    {
        boardSetup(); // create background
        initializeList();
        layoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum); // create wall tiles

        // set up enemy spawner
        int spawnCount = level;
        if(level == 0 || level == 1)
        {
            spawnCount = 2; // so we have enough array indices when getting a random spawn for an enemy
        }
        spawnLocs = new Vector3[spawnCount];
        for (int i = 0; i < spawnCount; ++i)
        {
            spawnLocs[i] = randomPosition();
        }
        
        // uncomment below to instantiate the exit portal
        // which is currently managed by manager.cs
        //Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }

    public void spawnInitialEnemies(int level)
    {
        int enemyCount = 3 * level; // initial amount of enemies that will spawn at random
                                    // places (not spawn locations)
        layoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
    }
}
