using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GeneralSpawner <T>: MonoBehaviour where T : MonoBehaviour, IPoolable<T>
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    protected ObjectPool<T> _pool;

    private List<T> _spawnedObjects = new List<T>();

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => {
                T prefab = Instantiate(_prefab);
                return prefab;
            },
            actionOnGet: (prefab) => PrepareObject(prefab),
            actionOnRelease: (prefab) => prefab.gameObject.SetActive(false),
            actionOnDestroy: (prefab) => Destroy(prefab.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public virtual void ResetSpawner()
    {
        StopAllCoroutines();
        ReleaseAllObjects();
    }

    public virtual void ReleaseObject(T prefab)
    {
        prefab.ReleaseToPool -= ReleaseObject;

        PrepareForRelease(prefab);
        _spawnedObjects.Remove(prefab);
        _pool.Release(prefab);
    }

    protected virtual void ReleaseAllObjects()
    {
        for (int i = _spawnedObjects.Count - 1; i >= 0; i--)
        {
            ReleaseObject(_spawnedObjects[i]);
        }
    }

    protected virtual void PrepareObject(T prefab)
    {
        prefab.gameObject.SetActive(true);
    }

    protected virtual T GetObject()
    {
        T prefab = _pool.Get();

        prefab.ReleaseToPool += ReleaseObject;

        if (_spawnedObjects.Contains(prefab) == false)
            _spawnedObjects.Add(prefab);

        return prefab;
    }

    protected virtual void PrepareForRelease(T prefab) { }
}