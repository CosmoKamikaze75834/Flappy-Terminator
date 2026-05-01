using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : PoolableRigidbody2D
{
    [SerializeField] private float _tapForñe;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    [SerializeField] private FlightAnimation _flightAnimation;
    [SerializeField] private InputSystem _inputSystem;

    private Vector3 _startPosition;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private float _minValue = 0;

    protected override void Awake()
    {
        base.Awake();

        _startPosition = transform.position;

        _minRotation = Quaternion.Euler(_minValue, _minValue, _minRotationZ);
        _maxRotation = Quaternion.Euler(_minValue, _minValue, _maxRotationZ);

        ResetState();
    }

    private void Update()
    {
        if (_inputSystem.MovePressed)
        {
            _flightAnimation.InstallAnimation();
            _flightAnimation.LaunchTimer();

            Rigidbody.velocity = new Vector2(_speed, _tapForñe);

            transform.rotation = _maxRotation;
        }

        _flightAnimation.ProcessingFlyTimes(_minValue);

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public override void ResetState()
    {
        base.ResetState();
        transform.position = _startPosition;
    }
}