using UnityEngine;

public class EnemySpawnPresetSelector : MonoBehaviour
{
    [SerializeField] private EnemySpawnPoints[] _spawnPreset;

    public EnemySpawnPoints SelectRandomPreset(int minValue)
    {
        if (_spawnPreset.Length == minValue)
            return null;

        int randomIndex = Random.Range(minValue, _spawnPreset.Length);

        return _spawnPreset[randomIndex];
    }
}