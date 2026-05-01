using System;
using UnityEngine;

public class PlayerBulletSpawner : GeneralSpawner<BulletPlayer>
{
    [SerializeField] private Transform _firePoint;

    public event Action<Enemy> EnemyHit;

    public void SpawnBullet()
    {
        BulletPlayer bullet = GetObject();

        bullet.transform.position = _firePoint.transform.position;
        bullet.transform.rotation = _firePoint.rotation;

        bullet.Attacked += OnBulletAttaked;
        bullet.BulletCollided += ReleaseObject;

        bullet.Launch(_firePoint.right);
    }

    protected override void PrepareObject(BulletPlayer bullet)
    {
        base.PrepareObject(bullet);
        bullet.ResetState();
    }

    protected override void PrepareForRelease(BulletPlayer bullet)
    {
        bullet.Attacked -= OnBulletAttaked;
        bullet.BulletCollided -= ReleaseObject;
    }

    private void OnBulletAttaked(BulletPlayer bullet, Enemy enemy)
    {
        EnemyHit?.Invoke(enemy);
    }
}