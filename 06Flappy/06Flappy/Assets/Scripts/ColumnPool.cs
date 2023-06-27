using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    
    public int columnPoolSize = 5;

    private GameObject[] columns;
    
    private float columnMin = -2.9f;
    private float columnMax = 1.4f;
    private float spawnXPosition = 10f;
    
    public GameObject columnPrefab;
    private Vector2 objectPoolPosition = new Vector2 (-14, 0);
    
    private float timeSinceLastSpawn;
    public float spawnRate;

    private int currentColumn;
    
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab,objectPoolPosition, Quaternion.identity);
        }
        SpawnColumn();
    }
    
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (!GameController.instance.gameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            SpawnColumn();
        }

    }
    private void SpawnColumn()
    {
        float spawnYPosition = Random.Range(columnMin, columnMax);
        columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
        currentColumn++;
        if (currentColumn >= columnPoolSize)
        {
            currentColumn = 0;
        }    
    }
}
