using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityUtils.Events
{
    // [CreateAssetMenu(fileName = "New X Game Event", menuName = "Events/X Game Event")]
    public abstract class GenericGameEvent <T>: ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GenericGameEventListener<T>> _eventListeners = 
            new List<GenericGameEventListener<T>>();
        
        private readonly List<Action<T>> _eventActions = 
            new List<Action<T>>();

        public void Raise(T obj)
        {
            for (var i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised(obj);
            }

            for (int i = _eventActions.Count - 1; i >= 0; i--)
            {
                _eventActions[i].Invoke(obj);
            }
        }

        public void RegisterAction(Action<T> action)
        {
            if (!_eventActions.Contains(action))
            {
                _eventActions.Add(action);
            }
        }
        
        public void UnregisterAction(Action<T> action)
        {
            if (_eventActions.Contains(action))
            {
                _eventActions.Remove(action);
            }
        }

        public void RegisterListener(GenericGameEventListener<T> listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(GenericGameEventListener<T> listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
            }
        }
    }
}