using System;
using System.Collections;
using UnityEngine;

public class PlayerBulletSpawner : GeneralSpawner<BulletPlayer>
{
    private const int Delay = 3;

    [SerializeField] private Transform _firePoint;

    private WaitForSeconds WaitForSeconds = new WaitForSeconds(Delay);

    public event Action<Enemy> BulletHitEnemy;

    protected override void PrepareObject(BulletPlayer bullet)
    {
        base.PrepareObject(bullet);
        bullet.ResetState();
    }

    public void GetBullet()
    {
        BulletPlayer bullet = GetObject();

        bullet.transform.position = _firePoint.transform.position;
        bullet.transform.rotation = _firePoint.transform.rotation;

        bullet.Attacked += OnBulletAttaked;
        

        bullet.Launch(_firePoint.right);

        StartCoroutine(TimeLifeBullet(bullet));
    }

    public void OnBulletAttaked(BulletPlayer bullet, Enemy enemy)
    {
        bullet.Attacked -= OnBulletAttaked;

        ReturnObject(bullet);

        BulletHitEnemy?.Invoke(enemy);
    }

    private IEnumerator TimeLifeBullet(BulletPlayer bullet)
    {
        yield return WaitForSeconds;

        if (bullet.gameObject.activeSelf)
        {
            bullet.Attacked -= OnBulletAttaked;
            ReturnObject(bullet);
        }
    }
}