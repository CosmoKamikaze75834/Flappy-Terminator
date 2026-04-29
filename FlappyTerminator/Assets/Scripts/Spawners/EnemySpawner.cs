using System.Collections;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class EnemySpawner : GeneralSpawner<Enemy>
{
    [SerializeField] private EnemySpawnPreset[] _spawnPreset;
    [SerializeField] private Transform _container;
    [SerializeField] private EnemyBulletSpawner _bulletSpawner;
    [SerializeField] private float _firstWaveDelay = 3f;

    [SerializeField] private Transform _spawnOutsidePoint;

    private float _delayBetweenWaves;

    private float _minTime = 3;
    private float _maxTime = 7;

    private int _aliveEnemiesCount;

    private void Start()
    {
        StartCoroutine(SpawnFirstWave());
    }

    protected override void PrepareObject(Enemy enemy)
    {
        base.PrepareObject(enemy);
        enemy.ResetState();
    }

    private void SpawnWave()
    {
        if(_spawnPreset.Length == 0)
        {
            return;
        }

        _aliveEnemiesCount = 0;

        int randomIndex = Random.Range(0, _spawnPreset.Length);
        EnemySpawnPreset selectedPreset = _spawnPreset[randomIndex];

        for (int i = 0; i < selectedPreset.SpawnPoint.Length; i++)
        {
            Enemy enemy = GetObject();
            _aliveEnemiesCount++;

            enemy.transform.parent = _container;
            enemy.transform.position = _spawnOutsidePoint.position;

            enemy.Died += OnEnemyDied;

            if (enemy.TryGetComponent(out AttackerEnemy attacker))
            {
                attacker.Init(_bulletSpawner);
                attacker.StopAttack();
            }

            Debug.Log("Target point: " + selectedPreset.SpawnPoint[i].position);
            Debug.Log("Enemy start: " + enemy.transform.position);

            enemy.MoveToPoint(selectedPreset.SpawnPoint[i].position);
        }
    }

    private IEnumerator SpawnFirstWave()
    {
        yield return new WaitForSeconds(_firstWaveDelay);
        SpawnWave();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _aliveEnemiesCount--;

        ReturnObject(enemy);

        if(_aliveEnemiesCount <= 0)
        {
            StartCoroutine(SpawnNextWave());
        }
    }

    private IEnumerator SpawnNextWave()
    {
        _delayBetweenWaves = Random.Range(_minTime, _maxTime);

        yield return new WaitForSeconds(_delayBetweenWaves);

        SpawnWave();
    }
}