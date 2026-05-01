using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PoolableRigidbody2D : MonoBehaviour
{
    protected Rigidbody2D Rigidbody { get; private set; }

    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void ResetState()
    {
        Rigidbody.velocity = Vector2.zero;
        transform.rotation = Quaternion.identity;
    }
}