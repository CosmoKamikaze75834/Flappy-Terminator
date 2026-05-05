using System;
using UnityEngine;

public class Enemy : PoolableRigidbody2D, IPoolable<Enemy>
{
    [SerializeField] private EnemyAttacker _attacker;

    private bool _isDead;

    public EnemyAttacker Attacker => _attacker;

    public event Action<Enemy> Died;
    public event Action<Enemy> ReleaseToPool;

    public void Die()
    {
        if (_isDead)
            return;

        _isDead = true;
        Died?.Invoke(this);
        ReleaseToPool?.Invoke(this);
    }

    public override void ResetState()
    {
        base.ResetState();
        _isDead = false;
    }
}