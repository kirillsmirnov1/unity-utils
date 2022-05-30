using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Variables;

namespace UnityUtils.View
{
    public class GameObjectEnabler : MonoBehaviour
    {
        [SerializeField] private Pair[] pairs;

        private List<Action<bool>> _actions;
        
        private void OnEnable()
        {
            InitActions();
            SetValues();
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i].flag.OnChange -= _actions[i];
            }
        }

        private void InitActions()
        {
            _actions = new List<Action<bool>>();
            for (int i = 0; i < pairs.Length; i++)
            {
                var iCaptured = i;
                _actions.Add(enable => { pairs[iCaptured].obj.SetActive(enable); });
            }
        }

        private void SetValues()
        {
            for (int i = 0; i < pairs.Length; i++)
            {
                _actions[i](pairs[i].flag);
            }
        }

        private void Subscribe()
        {
            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i].flag.OnChange += _actions[i];
            }
        }

        [Serializable]
        public struct Pair
        {
            public BoolVariable flag;
            public GameObject obj;
        }
    }
}