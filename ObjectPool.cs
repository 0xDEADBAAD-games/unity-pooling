using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CatPot.Framework.Utils.Pooling
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private PoolableObject _prefab;
        [SerializeField] private int _initialSize;
        [SerializeField] private BaseEmptyPoolStrategy _emptyPoolStrategy;

        private Queue<PoolableObject> _freeObjects;
        private List<PoolableObject> _activeObjects;

        private void Awake()
        {
            Debug.Assert(_prefab != null, "No prefab defined for the pool", gameObject);
            Debug.Assert(_emptyPoolStrategy != null, "No empty pool strategy defined for the pool", gameObject);
            Debug.Assert(_initialSize > 0, "Invalid size defined for the pool", gameObject);
        }

        private void Start()
        {
            _freeObjects = new Queue<PoolableObject>(_initialSize);
            _activeObjects = new List<PoolableObject>(_initialSize);

            for (int i = 0; i < _initialSize; i++)
            {
                AddObject();
            }
        }

        public GameObject GetObject()
        {
            if (_freeObjects.Count == 0)
            {
                GameObject failsafeObject = _emptyPoolStrategy.HandleEmptyPool(_freeObjects, _activeObjects, _prefab, AddObject).gameObject;

                if (failsafeObject != null)
                    return failsafeObject;
            }

            PoolableObject newObject = _freeObjects.Dequeue();
            _activeObjects.Add(newObject);

            return newObject.gameObject;
        }

        private void AddObject()
        {
            PoolableObject newObject = Instantiate(_prefab, transform);
            newObject.gameObject.SetActive(false);
            newObject.OnReturn.AddListener(() =>
            {
                ReturnObject(newObject);
                newObject.OnReset.Invoke();
            });

            _freeObjects.Enqueue(newObject);
        }

        private void ReturnObject(PoolableObject obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.parent = transform;

            _activeObjects.Remove(obj);

            _freeObjects.Enqueue(obj);
        }
    }
}