using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPooling : MonoBehaviour {

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);       //Position out of screen
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn;                            
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate;                                             //How often column is brought in front of player
    public float columnMin = -1f;
    public float columnMax = 3.5f;                                        //Minimum and maximun heights of column


	// Use this for initialization
	void Start ()
    {
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);    //Instantiate the prefab at the specified position. Identity Quaternion to keep prefab rotation
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if(GameController.instance.isGameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
	}
}
