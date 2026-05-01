using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private PlayerDeath _player;

    public event Action PlayerEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            _player.EstablishPause();
            PlayerEntered?.Invoke();
        }
    }
}