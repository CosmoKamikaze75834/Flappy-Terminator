using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameResetter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemyBulletSpawner _enemyBulletSpawner;
    [SerializeField] private PlayerBulletSpawner _playerBulletSpawner;
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private Player _player;

    public void PrepareNewGame()
    {
        _enemySpawner.ResetSpawner();
        _enemyBulletSpawner.ResetSpawner();
        _playerBulletSpawner.ResetSpawner();

        _player.ResetState();

        _enemySpawner.LaunchSpawner();

        _score.Reset();
    }
}