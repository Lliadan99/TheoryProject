using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;
    public bool gameOver = false;

    private string _rangedTag = "EnemyRanged";
    private string _meleeTag = "EnemyMelee";
    private string _tankTag = "EnemyTank";

    private float _startWait = 1.0f;
    private float _waveInterval = 4.0f;
    private float _spawnInterval = 0.5f;
    private int _enemiesPerWave = 1;

    private float _hX = 6.5f;
    private float _hZ = 15f;
    private float _vX = 24.5f;
    private float _vZ = 3.5f;

    private Vector3 _spawnPos;

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
            return new Vector3(Random.Range(-_hX, _hX), 0, _hZ);
        }
        else if (position == 2)
        {
            return new Vector3(Random.Range(-_hX, _hX), 0, -_hZ);
        }
        else if(position == 3)
        {
            return new Vector3(-_vX, 0, Random.Range(-_vZ, _vZ));
        }
        else
        {
            return new Vector3(_vX, 0, Random.Range(-_vZ, _vZ));
        }
    }

    IEnumerator SpawnEnemies()
    {
        if (!gameOver)
        {
            yield return new WaitForSeconds(_startWait);
            while (true)
            {
                for (int i = 0; i < _enemiesPerWave; i++)
                {
                    float enemySelect = Random.Range(0.0f, 14f);
                    int sp = Random.Range(0, 4);
                    _spawnPos = SpawnPosition(sp);
                    if (enemySelect < 5)
                    {
                        GetEnemy(_meleeTag);
                    }
                    else if (enemySelect >= 5 && enemySelect < 10)
                    {
                        GetEnemy(_tankTag);
                    }
                    else
                    {
                        GetEnemy(_rangedTag);
                    }
                    yield return new WaitForSeconds(_spawnInterval);
                }
                yield return new WaitForSeconds(_waveInterval);
                _enemiesPerWave++;
            }
        }
    }

    private void GetEnemy(string tag)
    {
        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(tag);
        if (enemy != null)
        {
            enemy.transform.position = _spawnPos;
            enemy.SetActive(true);
        }
    }
}
