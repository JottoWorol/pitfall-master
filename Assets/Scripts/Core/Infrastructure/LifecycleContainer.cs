using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Infrastructure
{
    public class LifecycleContainer : MonoBehaviour
    {
        private readonly List<object> _objects = new List<object>();

        public void Add(params object[] obj)
        {
            _objects.AddRange(obj);
        }

        private void Update()
        {
            foreach (var obj in _objects)
            {
                if(obj is IUpdateable updateable) updateable.OnUpdate();
            }
        }

        private void Start()
        {
            foreach (var obj in _objects)
            {
                if(obj is IStartable updateable) updateable.OnStart();
            }
        }

        private void OnDestroy()
        {
            foreach (var obj in _objects)
            {
                if(obj is IDestroyable updateable) updateable.OnDestroy();
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            foreach (var obj in _objects)
            {
                if(obj is IApplicationPauseListener listener) listener.OnApplicationPause(pauseStatus);
            }
        }
    }
}