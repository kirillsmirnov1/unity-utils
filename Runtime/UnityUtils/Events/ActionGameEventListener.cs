using System;
using UnityEngine;
using UnityEngine.Events;

namespace UnityUtils.Events
{
    public class ActionGameEventListener : GenericGameEventListener<Action>
    {
        [Tooltip("Event to register with.")]
        public ActionGameEvent gameEvent;

        [Tooltip("Response to invoke when Event is raised.")]
        public ActionUnityEvent response;

        protected override GenericGameEvent<Action> GameEvent => gameEvent;
        protected override UnityEvent<Action> Response => response;
    }
}