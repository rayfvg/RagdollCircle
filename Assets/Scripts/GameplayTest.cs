using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayTest : MonoBehaviour
{
    private Enemy _enemy;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    private void Awake()
    {
        _enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _enemy.Kill();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        Destroy(_enemy.gameObject);
        _enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
    }
}
