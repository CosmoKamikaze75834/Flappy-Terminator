using System.Collections;
using UnityEngine;

public class EnemySpawner : GeneralSpawner<Enemy>
{
    [SerializeField] private EnemySpawnPresetSelector _spawnPresetSelector;
    [SerializeField] private EnemyInitializer _initializer;
    [SerializeField] private EnemyBulletSpawner _bulletSpawner;

    private float _delayBetweenWaves;
    private float _minTime = 3;
    private float _maxTime = 5;

    private int _minValue = 0;
    private int _aliveEnemiesCount;

    public void LaunchSpawner()
    {
        StartCoroutine(SpawnNextWave());
    }

    public override void ResetSpawner()
    {
        base.ResetSpawner();
        _aliveEnemiesCount = _minValue;
    }

    protected override void PrepareObject(Enemy enemy)
    {
        base.PrepareObject(enemy);
        enemy.ResetState();
    }

    protected override void PrepareForRelease(Enemy enemy)
    {
        enemy.Died -= ProcessEnemyDied;

        if (enemy.TryGetComponent(out EnemyAttacker attacker))
            attacker.StopAttack();
    }

    private void SpawnWave()
    {
        _aliveEnemiesCount = _minValue;

        EnemySpawnPoints selectedPreset = _spawnPresetSelector.SelectRandomPreset(_minValue);

        for (int i = 0; i < selectedPreset.SpawnPoint.Length; i++)
        {
            Enemy enemy = GetObject();

            _aliveEnemiesCount++;

            _initializer.Initialize(enemy, selectedPreset.SpawnPoint[i], _bulletSpawner);

            enemy.Died += ProcessEnemyDied;
        }
    }

    private IEnumerator SpawnNextWave()
    {
        _delayBetweenWaves = Random.Range(_minTime, _maxTime);

        yield return new WaitForSeconds(_delayBetweenWaves);

        SpawnWave();
    }

    private void ProcessEnemyDied(Enemy enemy)
    {
        enemy.Died -= ProcessEnemyDied;
        _aliveEnemiesCount--;

        if (_aliveEnemiesCount <= _minValue)
            StartCoroutine(SpawnNextWave());
    }
}