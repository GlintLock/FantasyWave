using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 0.75f;
    public int waveNum = 1;
    public int enemyCount;
    public float spawnDelay;
    public float waveWait;
    public bool waveSpawningOn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWave(waveNum));
    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
    }
    private Vector2 SpawnEnemy()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);
        return randomPos;
    }
    void Spawner()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 && !waveSpawningOn)
        {
            waveNum++;
            StartCoroutine(SpawnEnemyWave(waveNum));
        }
    }
    IEnumerator SpawnEnemyWave(int numEnemies)
    {
        waveSpawningOn = true;
        yield return new WaitForSeconds(3);
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemyPrefab, SpawnEnemy(), enemyPrefab.transform.rotation);
   
        }
        waveSpawningOn = false;
    }
    
    
}
