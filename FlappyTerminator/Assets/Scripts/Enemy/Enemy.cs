using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Enemy : PoolableRigidbody2D
{
    public event Action<Enemy> Died;

    private bool _isAlive;
    private Vector3 _targetPosition;
    private bool _isMoving;

    public void Die()
    {
        if(_isAlive)
            return;

        _isAlive = true;
        Died?.Invoke(this);
    }

    public override void ResetState()
    {
        base.ResetState();
        _isAlive = false;
        _isMoving = false;
    }

    public void MoveToPoint(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        _isMoving = true;
    }

    private void Update()
    {
        if(_isMoving == false)
            return;

        Debug.Log("Следовать к точке");
        Debug.DrawLine(transform.position, _targetPosition, Color.red);
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * 2);


        if (Vector3.Distance(transform.position, _targetPosition) < 0.01f)
        {
            transform.position = _targetPosition;
            Debug.Log("Враги на месте");
            _isMoving = false;

            if (TryGetComponent(out AttackerEnemy attacker))
            {
                attacker.StartAttack();
            }
        }
    }
}