﻿using UnityEngine;

namespace UnityUtils.Saves
{
    public class InitScriptableObjects : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private InitiatedScriptableObject[] objectsToInit;
#pragma warning restore 0649

        private void Awake()
        {
            foreach (var obj in objectsToInit)
            {
                obj.Init();
            }
        }
    }
}