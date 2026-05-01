using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private PlayerBulletSpawner spawner;
    [SerializeField] private InputSystem _inputSystem;

    private void Update()
    {
        if (_inputSystem.AttackPressed)
        {
            spawner.SpawnBullet();
        }
    }
}