using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private GameObject[] _healthBonusTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondBetweenSpawn;
    [SerializeField] private float _secondSpawnHealthBonus;


    private float _elapsedTime;
    private float _elapsedHealthRecoveryTime;
    private int _spawnPointNumber;
    private int _spawnPointHealthBonus;

    private void Start()
    {
        Initialize(_enemyTemplates, _enemyPool);
        Initialize(_healthBonusTemplates, _healthBonusPool);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        _elapsedHealthRecoveryTime += Time.deltaTime;

        _spawnPointNumber = Random.Range(0, _spawnPoints.Length);

        if (_elapsedHealthRecoveryTime >= _secondSpawnHealthBonus)
        {
            if (TryGetObject(out GameObject healthBonus, _healthBonusPool))
            {
                _elapsedHealthRecoveryTime = 0;
                SetTriger(healthBonus, _spawnPoints[_spawnPointNumber].position);
                _spawnPointHealthBonus = _spawnPointNumber;
            }
        }
        else if (_elapsedTime >= _secondBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy, _enemyPool))
            {
                GetAnotherSpawnPointNumber();

                _elapsedTime = 0;
                SetTriger(enemy, _spawnPoints[_spawnPointNumber].position);
            }
        }
    }

    private void SetTriger(GameObject triger, Vector3 spawnPoint)
    {
        triger.SetActive(true);
        triger.transform.position = spawnPoint;
    }

    private void GetAnotherSpawnPointNumber()
    {
        while (_spawnPointHealthBonus == _spawnPointNumber)
        {
            _spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        }
    }
}
