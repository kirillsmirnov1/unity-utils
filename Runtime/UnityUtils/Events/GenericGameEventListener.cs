using UnityEngine;
using UnityEngine.Events;

namespace UnityUtils.Events
{
    public abstract class GenericGameEventListener <T> : MonoBehaviour
    {
        // Create this classes:
        //     XGameEvent : GenericGameEvent<X>
        //     [Serializable] XUnityEvent : UnityEvent<X>
        
        // [Tooltip("Event to register with.")]
        // public XGameEvent gameEvent;
        //
        // [Tooltip("Response to invoke when Event is raised.")]
        // public XUnityEvent response;

        protected abstract GenericGameEvent<T> GameEvent { get; }
        protected abstract UnityEvent<T> Response { get; }

        private void OnEnable()
        {
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T obj)
        {
            Response.Invoke(obj);
        }
    }
}