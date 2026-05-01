using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _minAttackDelay = 0.5f;
    [SerializeField] private float _maxAttackDelay = 2f;

    private EnemyBulletSpawner _spawner;

    private float _nextAttackTime;

    private bool _canAttack;

    private void Update()
    {
        if (_spawner == null)
            return;

        if (_canAttack == false)
            return;

        if (Time.time >= _nextAttackTime)
        {
            _spawner.SpawnBullet(_firePoint);
            _nextAttackTime = Time.time + Random.Range(_minAttackDelay, _maxAttackDelay);
        }
    }

    public void LaunchAttack()
    {
        _canAttack = true;
        _nextAttackTime = Time.time + Random.Range(_minAttackDelay, _maxAttackDelay);
    }

    public void StopAttack()
    {
        _canAttack = false;
    }

    public void Init(EnemyBulletSpawner spawner)
    {
        _spawner = spawner;
    }
}