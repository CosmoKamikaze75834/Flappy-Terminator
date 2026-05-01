using System;
using UnityEngine;

public class BulletEnemy : BulletBase
{
    public event Action<BulletEnemy> BulletCollided;
    public event Action PlayerHit;

    public void Launch()
    {
        Launch(Vector2.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            PlayerHit?.Invoke();
            BulletCollided?.Invoke(this);
        }
        else if (collision.TryGetComponent<ObjectRemover>(out _))
            BulletCollided?.Invoke(this);
    }
}