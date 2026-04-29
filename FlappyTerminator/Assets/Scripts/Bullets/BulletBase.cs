using UnityEngine;

public class BulletBase : PoolableRigidbody2D
{
    [SerializeField] private float _speed = 20f;

    public void Launch(Vector2 direction)
    {
        _rigidbody.velocity = direction.normalized * _speed;
    }
}