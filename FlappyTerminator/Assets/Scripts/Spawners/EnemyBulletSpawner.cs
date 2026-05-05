using UnityEngine;

public class EnemyBulletSpawner : GeneralSpawner<Bullet>
{
    public void SpawnBullet(Transform firePoint)
    {
        Bullet bullet = GetObject();

        bullet.transform.position = firePoint.position;

        bullet.TargetHit += OnTargetHit;

        bullet.Launch(Vector2.left);
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
        if (collision.TryGetComponent(out Player player))
        {
            player.Die();
        }
    }
}