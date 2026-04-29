using UnityEngine;

public class EnemySpawnPreset : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;

    public Transform[] SpawnPoint => _spawnPoint;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (_spawnPoint == null)
            return;

        for (int i = 0; i < _spawnPoint.Length; i++)
        {
            if (_spawnPoint[i] == null)
                continue;

            Gizmos.DrawSphere(_spawnPoint[i].position, 0.2f);
        }
    }
}