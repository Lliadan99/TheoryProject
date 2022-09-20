using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;
    public bool gameOver = false;

    private string rangedTag = "EnemyRanged";
    private string meleeTag = "EnemyMelee";
    private string tankTag = "EnemyTank";

    private float startWait = 1.0f;
    private float waveInterval = 4.0f;
    private float spawnInterval = 0.5f;
    private int enemiesPerWave = 1;

    private float hX = 6.5f;
    private float hZ = 15f;
    private float vX = 24.5f;
    private float vZ = 4.5f;

    private Vector3 spawnPos;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    private void Update()
    {
        if (gameOver)
        {

        }
    }

    private Vector3 SpawnPosition(int position)
    {
        if(position == 1)
        {
            return new Vector3(Random.Range(-hX, hX), 0, hZ);
        }
        else if (position == 2)
        {
            return new Vector3(Random.Range(-hX, hX), 0, -hZ);
        }
        else if(position == 3)
        {
            return new Vector3(-vX, 0, Random.Range(-vZ, vZ));
        }
        else
        {
            return new Vector3(vX, 0, Random.Range(-vZ, vZ));
        }
    }

    IEnumerator SpawnEnemies()
    {
        if (!gameOver)
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    float enemySelect = Random.Range(0.0f, 14f);
                    int sp = Random.Range(0, 4);
                    spawnPos = SpawnPosition(sp);
                    if (enemySelect < 5)
                    {
                        GetEnemy(meleeTag);
                    }
                    else if (enemySelect >= 5 && enemySelect < 10)
                    {
                        GetEnemy(tankTag);
                    }
                    else
                    {
                        GetEnemy(rangedTag);
                    }
                    yield return new WaitForSeconds(spawnInterval);
                }
                yield return new WaitForSeconds(waveInterval);
                enemiesPerWave++;
            }
        }
    }

    private void GetEnemy(string tag)
    {
        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(tag);
        if (enemy != null)
        {
            enemy.transform.position = spawnPos;
            enemy.SetActive(true);
        }
    }
}
