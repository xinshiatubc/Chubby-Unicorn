using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab;
    private int objectPoolSize = 5;
    private float spawnRate = 1.5f;
    private float minPos = -1f;
    private float maxPos = 1f;

    //object pool
    private GameObject[] objects;
    //Index of the current object in the collection.
    private int currentObject = 0;

    //A holding position for the unused object offscreen
    private Vector2 initPosition = new Vector2(-15f, -25f);
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;

        //Initialize the object pool
        objects = new GameObject[objectPoolSize];
        //create indivial object 
        for (int i = 0; i < objectPoolSize; i++)
        {
            objects[i] = (GameObject)Instantiate(objectPrefab, initPosition, Quaternion.identity);
        }
    }


    //This spawns columns indefinitely until game is over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            //Set the object to a random y position 
            float spawnYPosition = Random.Range(minPos, maxPos);
            objects[currentObject].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            //Increase current object index. Reset if out of pool size
            currentObject++;

            if (currentObject >= objectPoolSize)
            {
                currentObject = 0;
            }
        }
    }
}
