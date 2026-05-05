using UnityEngine;

public class FlightAnimation : MonoBehaviour
{
    [SerializeField] private AnimationActions _animation;

    private float _flightTimer = 0f;
    private float _flightDuration = 0.5f;
    private float _minValue = 0f;


    public void InstallAnimation()
    {
        _animation.EstablishFly(true);
    }

    public void LaunchTimer()
    {
        _flightTimer = _flightDuration;
    }

    public void ProcessingFlyTimes()
    {
        if (_flightTimer > _minValue)
        {
            _flightTimer -= Time.deltaTime;

            if (_flightTimer <= _minValue)
            {
                _animation.EstablishFly(false);
            }
        }
    }

    public void ResetState()
    {
        _flightTimer = _minValue;
        _animation.EstablishFly(false);
    }
}