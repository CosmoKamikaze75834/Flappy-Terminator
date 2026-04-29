using System;
using UnityEngine;

public class BulletPlayer : BulletBase
{
    public event Action<BulletPlayer, Enemy> Attacked;

    private void Start()
    {
        Launch(transform.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
            Attacked?.Invoke(this, enemy);
    }
}