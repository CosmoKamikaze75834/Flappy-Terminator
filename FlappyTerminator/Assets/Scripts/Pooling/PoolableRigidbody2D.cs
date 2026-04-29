using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PoolableRigidbody2D : MonoBehaviour
{
    protected Rigidbody2D _rigidbody { get; private set; }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void ResetState()
    {
        _rigidbody.velocity = Vector2.zero;
        transform.rotation = Quaternion.identity;
    }
}