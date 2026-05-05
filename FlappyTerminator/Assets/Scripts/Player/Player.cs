using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAttacker _attacker;
    [SerializeField] private FlightAnimation _flightAnimation;

    private bool _isDead;

    public event Action Died;

    public void Die()
    {
        if(_isDead) 
            return;

        _isDead = true;

        DisableControl();

        Died?.Invoke();
    }

    public void EnableControl()
    {
        _playerMover.enabled = true;
        _attacker.enabled = true;
    }

    public void DisableControl()
    {
        _playerMover.enabled = false;
        _attacker.enabled = false;
    }

    public void ResetState()
    {
        _isDead = false;
        _playerMover.ResetState();
        _flightAnimation.ResetState();  
    }
}