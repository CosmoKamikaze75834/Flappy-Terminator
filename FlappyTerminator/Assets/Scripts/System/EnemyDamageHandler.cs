using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    [SerializeField] private PlayerBulletSpawner _playerBulletSpawner;
    [SerializeField] private ScoreCounter _score;

    private void OnEnable()
    {
        _playerBulletSpawner.EnemyHit += OnBulletHitEnemy;
    }

    private void OnDisable()
    {
        _playerBulletSpawner.EnemyHit -= OnBulletHitEnemy;
    }

    private void OnBulletHitEnemy(Enemy enemy)
    {
        enemy.Die();
        _score.Add();
    }
}