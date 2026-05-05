using System;
using UnityEngine;

public class Bullet : PoolableRigidbody2D, IPoolable<Bullet>
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private LayerMask _removerLayer;
    [SerializeField] private float _speed = 20f;

    private const int LayerBit = 1;
    private const int EmptyMask = 0;

    public event Action<Bullet,Collider2D> TargetHit;
    public event Action<Bullet> ReleaseToPool;

    public void Launch(Vector2 direction)
    {
        Rigidbody.velocity = direction.normalized * _speed;
    }

    public override void ResetState()
    {
        base.ResetState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsInLayerMask(collision, _targetLayer))
        {
            TargetHit?.Invoke(this, collision);
            ReleaseToPool?.Invoke(this);
        }
        else if (IsInLayerMask(collision, _removerLayer))
            ReleaseToPool?.Invoke(this);
    }

    private bool IsInLayerMask(Collider2D collision, LayerMask targetLayer)
    {
        return (targetLayer.value & (LayerBit << collision.gameObject.layer)) != EmptyMask;
    }
}