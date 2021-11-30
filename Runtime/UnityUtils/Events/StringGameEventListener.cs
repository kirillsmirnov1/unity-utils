using UnityEngine;
using UnityEngine.Events;

namespace UnityUtils.Events
{
    public class StringGameEventListener : GenericGameEventListener<string>
    {
        [Tooltip("Event to register with.")]
        public StringGameEvent gameEvent;
        [Tooltip("Response to invoke when Event is raised.")]
        public StringUnityEvent response;

        protected override GenericGameEvent<string> GameEvent => gameEvent;
        protected override UnityEvent<string> Response => response;
    }
}