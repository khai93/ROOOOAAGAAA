using System.Collections.Generic;
using UnityEngine;

namespace ROOOOAAGAAA.Core
{
    public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T prefab;

        private Queue<T> objects = new Queue<T>();
        public static GenericObjectPool<T> Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public T Get()
        {
            if (objects.Count == 0)
            {
                AddObjects(1);
            }

            return objects.Dequeue();
        }

        private void AddObjects(int count)
        {
            var newObject = GameObject.Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            objects.Enqueue(newObject);
        }

        public void ReturnToPool(T objectToReturn)
        {
            objectToReturn.gameObject.SetActive(false);
            objects.Enqueue(objectToReturn);
        }
    }
}