using UnityEngine;
using UnityEngine.Events;

namespace UnityUtils.Events
{
    public class IntGameEventListener : GenericGameEventListener<int>
    {
        [Tooltip("Event to register with.")]
        public IntGameEvent gameEvent;

        [Tooltip("Response to invoke when Event is raised.")]
        public IntUnityEvent response;

        protected override GenericGameEvent<int> GameEvent => gameEvent;
        protected override UnityEvent<int> Response => response;
    }
}