using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;

    public Transform[] SpawnPoint => _spawnPoint;
}