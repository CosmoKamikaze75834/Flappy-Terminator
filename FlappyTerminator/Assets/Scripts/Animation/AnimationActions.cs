using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationActions : MonoBehaviour
{
    private static readonly int IsFlight = Animator.StringToHash(nameof(IsFlight));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void EstablishFly(bool isFlight)
    {
        _animator.SetBool(IsFlight, isFlight);
    }
}