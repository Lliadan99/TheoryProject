using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;
    public bool gameOver = false;
    public TextMeshProUGUI score;
    public GameObject gameOverUI;
    public GameObject retry;
    public GameObject quit;
    public GameObject player;
    public GameObject[] hearts;

    private int _score = 0;

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

    private int _numberOfHearts;
    private int _arrayLength;

    private void Awake()
    {
        gameOverUI.SetActive(false);
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
            gameOverUI.SetActive(true);
        }
    }
    IEnumerator SpawnEnemies()
    {
        {
            yield return new WaitForSeconds(_startWait);
            while (!gameOver)
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

    private void GetEnemy(string tag)
    {
        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(tag);
        if (enemy != null)
        {
            enemy.transform.position = _spawnPos;
            enemy.SetActive(true);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        score.text = ("" + _score);
    }
    public void HeartDisplay(int health)
    {
        _numberOfHearts = health / 5;
        _arrayLength = hearts.Length;
        for(int i= _arrayLength; i> _numberOfHearts; i--)
        {
            hearts[i-1].SetActive(false);
        }
    }
}
