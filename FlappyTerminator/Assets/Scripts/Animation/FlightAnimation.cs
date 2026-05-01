using UnityEngine;

public class FlightAnimation : MonoBehaviour
{
    [SerializeField] private AnimationActions _animation;

    private float _flightTimer = 0f;
    private float _flightDuration = 0.5f; 

    public void InstallAnimation()
    {
        _animation.EstablishFly(true);
    }

    public void LaunchTimer()
    {
        _flightTimer = _flightDuration;
    }

    public void ProcessingFlyTimes(float minValue)
    {
        if (_flightTimer > minValue)
        {
            _flightTimer -= Time.deltaTime;

            if (_flightTimer <= minValue)
            {
                _animation.EstablishFly(false);
            }
        }
    }
}