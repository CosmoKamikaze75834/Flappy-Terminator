using System;
using UnityEngine;

public class BulletPlayer : BulletBase
{
    public event Action<BulletPlayer, Enemy> Attacked;
    public event Action<BulletPlayer> BulletCollided;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            Attacked?.Invoke(this, enemy);
            BulletCollided?.Invoke(this);
        }
        else if (collision.TryGetComponent<ObjectRemover>(out _))
            BulletCollided?.Invoke(this);
    }
}