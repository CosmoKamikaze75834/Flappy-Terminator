using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _timePlay = 0;

    public void EstablishPause()
    {
        TurnOffMovement();

        Time.timeScale = _timePlay;
    }

    private void TurnOffMovement()
    {
        if (_player.TryGetComponent(out PlayerMover component))
            component.enabled = false;
    }
}