using System;
using System.Collections;
using UnityEngine;

namespace Packages.UnityUtils.Extensions
{
    public static class MonoBehaviourExt
    {
        public static void DelayAction(this MonoBehaviour mono, float delay, Action action)
        {
            mono.StartCoroutine(DelayCoroutine());
            
            IEnumerator DelayCoroutine()
            {
                yield return new WaitForSeconds(delay);
                action?.Invoke();
            }
        }
    }
}