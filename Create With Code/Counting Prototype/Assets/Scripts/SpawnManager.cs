using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject[] spawnObjects;
    private Vector3 spawnPos;
    private int randomSpawn;

    float spawnRangeXmin = -20;
    float spawnRangeXmax = 15;
    float spawnStart = 2f;
    float interval = 1f;
    float intervalCoin = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        InvokeRepeating("SpawnTreasure", spawnStart, interval);
        InvokeRepeating("SpawnCoins", spawnStart, intervalCoin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTreasure()
    {
        spawnPos = new Vector3(Random.Range(spawnRangeXmin, spawnRangeXmax), 30, 0);
        randomSpawn = Random.Range(0, spawnObjects.Length);
        Instantiate(spawnObjects[randomSpawn], spawnPos, spawnObjects[randomSpawn].transform.rotation);
    }
    void SpawnCoins()
    {
        spawnPos = new Vector3(Random.Range(spawnRangeXmin, spawnRangeXmax), 30, 0);
        Instantiate(spawnObjects[0], spawnPos, spawnObjects[0].transform.rotation);
    }
}
