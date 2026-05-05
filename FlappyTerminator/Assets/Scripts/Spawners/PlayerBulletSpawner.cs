using System;
using UnityEngine;

public class PlayerBulletSpawner : GeneralSpawner<Bullet>
{
    [SerializeField] private Transform _firePoint;

    public event Action<Enemy> EnemyHit;

    public void SpawnBullet()
    {
        Bullet bullet = GetObject();

        bullet.transform.position = _firePoint.transform.position;
        bullet.transform.rotation = _firePoint.rotation;

        bullet.TargetHit += OnTargetHit;

        bullet.Launch(_firePoint.right);
    }


    protected override void PrepareObject(Bullet bullet)
    {
        base.PrepareObject(bullet);
        bullet.ResetState();
    }

    protected override void PrepareForRelease(Bullet bullet)
    {
        bullet.TargetHit -= OnTargetHit;
    }

    private void OnTargetHit(Bullet bullet, Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            EnemyHit?.Invoke(enemy);
        }
    }
}