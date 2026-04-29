using UnityEngine;

public class EnemyBulletSpawner : GeneralSpawner<BulletEnemy>
{
    [SerializeField] private PlayerDeath _playerDeath;

    protected override void PrepareObject(BulletEnemy bullet)
    {
        base.PrepareObject(bullet);
        bullet.ResetState();
    }

    public void GetBullet(Transform firePointPosition)
    {
        BulletEnemy bullet = GetObject();

        bullet.transform.position = firePointPosition.position;
        bullet.transform.rotation = firePointPosition.rotation;

        bullet.BulletCollided += ReturnObject;
        bullet.PlayerHit += _playerDeath.EstablishPause;
        bullet.Launch();
    }

    public override void ReturnObject(BulletEnemy bulletEnemy)
    {
        bulletEnemy.BulletCollided -= ReturnObject;
        bulletEnemy.PlayerHit -= _playerDeath.EstablishPause;
        base.ReturnObject(bulletEnemy);
    }
}