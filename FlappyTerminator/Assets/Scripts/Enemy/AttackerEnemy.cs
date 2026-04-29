using System.Collections;
using UnityEngine;

public class AttackerEnemy : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _attackDelay = 3f;

    private EnemyBulletSpawner _spawner;
    private float _nextAttackTime;

    private float _minTime = 0.5f;
    private float _maxTime = 1.5f;

    private bool _canAttack;

    public void StartAttack()
    {
        _canAttack = true;
        _nextAttackTime = Time.time + Random.Range(_minTime, _maxTime);
    }

    public void StopAttack()
    {
        _canAttack = false;
    }


    public void Init(EnemyBulletSpawner spawner)
    {
        _spawner = spawner;
    }

    private void Update()
    {
        if (_spawner == null)
            return;

        if(_canAttack == false)
            return;

        if (Time.time >= _nextAttackTime)
        {
            _spawner.GetBullet(_firePoint);
            _nextAttackTime = Time.time + Random.Range(_minTime, _maxTime);
        }
    }
}