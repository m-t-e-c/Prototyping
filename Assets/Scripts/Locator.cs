using System;
using System.Collections.Generic;
using UnityEngine;

namespace FishingIdle
{
    public class Locator
    {
        static          Locator                  instance;
        static          object                   syncRoot  = new();
        static readonly Dictionary<Type, object> _managers = new();

        public static Locator Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                lock (syncRoot)
                {
                    instance ??= new Locator();
                }

                return instance;
            }
        }

        public void Register<T>(object manager)
        {
            lock (syncRoot)
            {
                if (_managers.ContainsKey(typeof(T)))
                {
                    _managers[typeof(T)] = manager;
                }
                else
                {
                    _managers.Add(typeof(T), manager);
                }
            }
        }

        public T Resolve<T>()
        {
            lock (syncRoot)
            {
                if (!_managers.TryGetValue(typeof(T), out object manager))
                {
                    Debug.LogError($"Manager not found {(typeof(T).Name)}");
                }

                return (T)manager;
            }
        }

        public void Reset()
        {
            lock (syncRoot)
            {
                _managers.Clear();
            }
        }
    }
}