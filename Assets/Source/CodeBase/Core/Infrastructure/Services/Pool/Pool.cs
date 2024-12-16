using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.CodeBase.Core.Infrastructure.Services.Pool
{
    public class Pool<T> where T : MonoBehaviour
    {
        private readonly Func<T> _creator;
        private readonly Queue<T> _objects;

        public Pool(Func<T> creator)
        {
            _objects = new Queue<T>();
            _creator = creator;
        }

        public T Get()
        {
            T obj;

            if (_objects.Count > 0)
            {
                obj = _objects.Dequeue();
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj = _creator.Invoke();
            }

            return obj;
        }

        public void Put(T obj)
        {
            obj.gameObject.SetActive(false);
            _objects.Enqueue(obj);
        }
    }
}
