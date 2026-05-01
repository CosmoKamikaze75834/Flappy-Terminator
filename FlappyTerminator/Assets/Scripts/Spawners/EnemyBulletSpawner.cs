using System;
using UnityEngine;

public class EnemyBulletSpawner : GeneralSpawner<BulletEnemy>
{
    public event Action PlayerHit;

    public void SpawnBullet(Transform firePoint)
    {
        BulletEnemy bullet = GetObject();

        bullet.transform.position = firePoint.position;

        bullet.BulletCollided += ReleaseObject;
        bullet.PlayerHit += OnPlayerHit;
        bullet.Launch();
    }

    protected override void PrepareObject(BulletEnemy bullet)
    {
        base.PrepareObject(bullet);
        bullet.ResetState();
    }

    protected override void PrepareForRelease(BulletEnemy bulletEnemy)
    {
        bulletEnemy.BulletCollided -= ReleaseObject;
        bulletEnemy.PlayerHit -= OnPlayerHit;
    }

    private void OnPlayerHit()
    {
        PlayerHit?.Invoke();
    }
}