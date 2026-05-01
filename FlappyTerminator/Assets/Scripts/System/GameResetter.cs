using UnityEngine;

public class GameResetter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemyBulletSpawner _enemyBulletSpawner;
    [SerializeField] private PlayerBulletSpawner _playerBulletSpawner;
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private PlayerMover _playerMover;

    public void PrepareNewGame()
    {
        _enemySpawner.ResetSpawner();
        _enemyBulletSpawner.ResetSpawner();
        _playerBulletSpawner.ResetSpawner();

        _playerMover.ResetState();

        _enemySpawner.LaunchSpawner();

        _score.Reset();
    }
}