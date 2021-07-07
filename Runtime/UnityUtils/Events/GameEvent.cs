using System;
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
        
        private readonly List<Action> _eventActions = 
            new List<Action>();

        public void Raise()
        {
            for (var i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised();
            }

            for (int i = _eventActions.Count - 1; i >= 0; i--)
            {
                _eventActions[i].Invoke();
            }
        }

        public void RegisterAction(Action action)
        {
            if (!_eventActions.Contains(action))
            {
                _eventActions.Add(action);
            }
        }
        
        public void UnregisterAction(Action action)
        {
            if (_eventActions.Contains(action))
            {
                _eventActions.Remove(action);
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