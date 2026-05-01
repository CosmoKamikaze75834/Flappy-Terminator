using UnityEngine;

public class EnemyInitializer : MonoBehaviour
{
    [SerializeField] private Transform _container;

    public void Initialize(Enemy enemy, Transform spawnPoint, EnemyBulletSpawner bulletSpawner)
    {
        enemy.transform.parent = _container;
        enemy.transform.position = spawnPoint.position;

        if (enemy.TryGetComponent(out EnemyAttacker attacker))
        {
            attacker.Init(bulletSpawner);
            attacker.LaunchAttack();
        }
    }
}