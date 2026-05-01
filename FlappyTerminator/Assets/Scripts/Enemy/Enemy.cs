using System;
using Vector3 = UnityEngine.Vector3;

public class Enemy : PoolableRigidbody2D
{
    public event Action<Enemy> Died;

    private bool _isDead;

    private void Update()
    {
        Vector3 position = transform.position;
        position.z = 3;
        transform.position = position;
    }

    public void Die()
    {
        if (_isDead)
            return;

        _isDead = true;
        Died?.Invoke(this);
    }

    public override void ResetState()
    {
        base.ResetState();
        _isDead = false;
    }
}