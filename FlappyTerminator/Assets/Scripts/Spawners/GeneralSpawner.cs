using UnityEngine;
using UnityEngine.Pool;

public class GeneralSpawner <T>: MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<T> _pool;

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

    protected virtual void PrepareObject(T prefab)
    {
        prefab.gameObject.SetActive(true);
    }

    public virtual void ReturnObject(T prefab)
    {
        _pool.Release(prefab);
    }

    protected virtual T GetObject()
    {
        return _pool.Get();
    }
}