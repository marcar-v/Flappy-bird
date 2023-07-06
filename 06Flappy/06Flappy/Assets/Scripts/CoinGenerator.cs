using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public int coinPoolSize = 5;

    private GameObject[] coin;

    private float coinMin = -2f;
    private float coinMax = 4f;
    private float spawnXPosition = 12f;

    public GameObject coinPrefab;
    private Vector2 objectPoolPosition = new Vector2(-14, 0);

    private float timeSinceLastSpawn;
    public float spawnRate;

    private int currentCoin;

    // Start is called before the first frame update
    void Start()
    {
        coin = new GameObject[coinPoolSize];
        for (int i = 0; i < coinPoolSize; i++)
        {
            coin[i] = Instantiate(coinPrefab, objectPoolPosition, Quaternion.identity);
        }
        SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (!GameController.instance.gameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            SpawnCoin();
        }

    }
    public void SpawnCoin()
    {
        float spawnYPosition = Random.Range(coinMin, coinMax);
        coin[currentCoin].transform.position = new Vector2(spawnXPosition, spawnYPosition);
        currentCoin++;
        if (currentCoin >= coinPoolSize)
        {
            currentCoin = 0;
        }
    }
}