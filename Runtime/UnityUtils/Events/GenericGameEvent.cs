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

        public void Raise(T obj)
        {
            for (var i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised(obj);
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