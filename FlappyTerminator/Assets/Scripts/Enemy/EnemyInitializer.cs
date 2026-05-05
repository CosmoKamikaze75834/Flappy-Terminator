using UnityEngine;

public class EnemyInitializer : MonoBehaviour
{
    [SerializeField] private Transform _container;

    public void Initialize(Enemy enemy, Transform spawnPoint, EnemyBulletSpawner bulletSpawner)
    {
        enemy.transform.parent = _container;
        enemy.transform.position = spawnPoint.position;

        if (enemy.Attacker != null)
        {
            enemy.Attacker.Init(bulletSpawner);
            enemy.Attacker.LaunchAttack();
        }
    }
}