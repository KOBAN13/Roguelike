using System;
using System.Collections.Generic;
using System.Linq;
using Enemy.Interface;
using UnityEngine;
using Zenject;

namespace PoolObject
{
    public class PoolObject<TObject> where TObject : MonoBehaviour
    {
        private Dictionary<string, Queue<ObjectInPool>> _poolObject;
        private DiContainer _container;

        public bool AutoExpandPool;

        public PoolObject(DiContainer container)
        {
            _poolObject = new Dictionary<string, Queue<ObjectInPool>>();
            _container = container;
        }

        public void AddElementsInPool(string keyObjectInPool, IPrefab objectInPool, float countElementsWillBeInPool = 1f)
        {
            if (_poolObject.ContainsKey(keyObjectInPool))
            {
                AddElement(countElementsWillBeInPool, keyObjectInPool, objectInPool);
            }
            else
            {
                _poolObject.Add(keyObjectInPool, new Queue<ObjectInPool>());
                AddElement(countElementsWillBeInPool, keyObjectInPool, objectInPool);
            }
        }

        private void AddElement(float countElementsWillBeInPool, string keyObjectInPool, IPrefab objectInPool)
        {
            for (var i = 0; i < countElementsWillBeInPool; i++)
            {
                AddObjectInPool(keyObjectInPool, objectInPool, false);
            }
        }

        private TObject AddObjectInPool(string keyObjectInPool, IPrefab prefabObject, bool isActive)
        {
            var objectInPool = CreateNewEnemy(prefabObject);
            objectInPool.gameObject.SetActive(isActive);
            _poolObject[keyObjectInPool].Enqueue(new ObjectInPool(objectInPool, prefabObject));
            return objectInPool;
        }
        
        private TObject CreateNewEnemy(IPrefab prefabObject)
        {
            return _container.InstantiatePrefabForComponent<TObject>(prefabObject.Prefab);
        }

        public TObject GetElementInPool(string keyObjectInPool)
        {
            if (HasFreeElementInPool(out var objectInPool, keyObjectInPool))
                return objectInPool;

            if (!AutoExpandPool)
                throw new ArgumentException(
                    "There was no specified object in the pool because there is no auto-occupancy flag");

            return _poolObject[keyObjectInPool].Where(objectPool => objectPool.TypeObject.gameObject.activeInHierarchy)
                .Select(objectPool => AddObjectInPool(keyObjectInPool, objectPool.PrefabObject, false)).FirstOrDefault();
        }

        private bool HasFreeElementInPool(out TObject objectInPool, string keyObjectInPool)
        {
            foreach (var objectPool in _poolObject[keyObjectInPool].Where(objectPool => !objectPool.TypeObject.gameObject.activeInHierarchy))
            {
                objectInPool = objectPool.TypeObject;
                objectInPool.gameObject.SetActive(true);
                return true;
            }

            objectInPool = null;
            return false;
        }
        
        private class ObjectInPool
        {
            public readonly TObject TypeObject;
            public readonly IPrefab PrefabObject;
            
            public ObjectInPool(TObject typeObject, IPrefab prefabObject)
            {
                if (typeObject == null || prefabObject == null)
                    throw new ArgumentNullException($"One of the arguments construct is null {typeObject} or {prefabObject}");

                TypeObject = typeObject;
                PrefabObject = prefabObject;
            }
        }
    }
}