using System.Collections.Generic;
using UnityEngine;

namespace UnityUtils.Events
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener> _eventListeners = 
            new List<GameEventListener>();

        public void Raise()
        {
            for (var i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
            }
        }
    }
}