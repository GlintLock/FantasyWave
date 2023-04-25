using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Vector2 randomPos = new Vector2(spawnPosX, spawnPosY);
        Instantiate(enemyPrefab, new Vector2(-0.70f, 0.70f), enemyPrefab.transform.rotation);       
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
