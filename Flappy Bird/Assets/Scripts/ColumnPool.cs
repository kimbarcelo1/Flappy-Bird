using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f; //How quickly columns spawn.


    public float columnMin = -1f; //Minimum y value of the column position.
    public float columnMax = 3.5f; //Maximum y value of the column position.
    float spawnXPosition = 10f;
    int currentColumn = 0; //Index of the current column in the collection.

    Vector2 objectPoolPosition = new Vector2(-15f, -25f); //A holding position for our unused columns offscreen.
    GameObject[] columns; //Collection of pooled columns.

    float timeSinceLastSpawned;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the columns collection.
        columns = new GameObject[columnPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < columnPoolSize; i++)
        {
            //...and create the individual columns.
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    //This spawns columns as long as the game is not over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime; //counting up

        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;

            //Set a random y position for the column
            float spawnYPosition = Random.Range(columnMin, columnMax);

            //...then set the current column to that position.
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++; //Increase the value of currentColumn. If the new size is too big, set it back to zero
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
