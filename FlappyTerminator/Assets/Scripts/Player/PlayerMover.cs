using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForse;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private AnimationActions _animation;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private float _minValue = 0;

    private float _flyTimer = 0f;
    private float _flyDuration = 0.5f;

    private void Awake()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();

        _minRotation = Quaternion.Euler(_minValue, _minValue, _minRotationZ);
        _maxRotation = Quaternion.Euler(_minValue, _minValue, _maxRotationZ);

        Reset();
    }

    private void Update()
    {
        if (_inputSystem.MovePressed)
        {
            _animation.EstablishFly(true);
            _flyTimer = _flyDuration;

            _rigidbody.velocity = new Vector2(_speed, _tapForse);

            transform.rotation = _maxRotation;
        }

        ProcessingFlyTimes();

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void ProcessingFlyTimes()
    {
        if (_flyTimer > _minValue)
        {
            _flyTimer -= Time.deltaTime;

            if (_flyTimer <= _minValue)
            {
                _animation.EstablishFly(false);
            }
        }
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
        transform.rotation = Quaternion.identity;
    }
}