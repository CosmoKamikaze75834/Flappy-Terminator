using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private const KeyCode MoveKey = KeyCode.Space;
    private const KeyCode AttackKey = KeyCode.E;

    public bool MovePressed {  get; private set; }
    public bool AttackPressed { get; private set; }

    private void Update()
    {
        MovePressed = Input.GetKeyDown(MoveKey);
        AttackPressed = Input.GetKeyDown(AttackKey);
    }
}