using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ObjectPool<T> where T : Component
    {
        private readonly List<T> pool;
        private readonly T prefab;
        private readonly int amountToPool;

        public ObjectPool(T prefab, int amount)
        {
            this.prefab = prefab;
            amountToPool = amount;
            pool = new List<T>();

            for (int i = 0; i < amountToPool; i++)
            {
                T objInstance = Object.Instantiate(prefab);
                objInstance.gameObject.SetActive(false);
                pool.Add(objInstance);
            }
        }

        public T GetPooledObject()
        {
            foreach (var obj in pool)
            {
                if (obj != null && !obj.gameObject.activeInHierarchy)
                {
                    obj.gameObject.SetActive(true);
                    return obj;
                }
            }
        
            T newObjInstance = Object.Instantiate(prefab);
            newObjInstance.gameObject.SetActive(true);
            pool.Add(newObjInstance);
            return newObjInstance;
        }

        public void ReturnObjectToPool(T obj)
        {
            if (obj != null)
            {
                obj.gameObject.SetActive(false);
            }
        }
    }
}