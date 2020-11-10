using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.VisualEffects
{
    /// <summary>
    /// Fades alpha of all sprites in object and children from alpha 1 to 0 and back
    /// </summary>
    public class LazyFade : MonoBehaviour
    {
        private const float FadeDuration = 0.25f;
        protected float FadeSeconds => FadeDuration;
        protected const int FadeSteps = 10;
        
        private SpriteRenderer[] _sr;
        private Graphic[] _graphic; // Image, Both of TMPro classes
        
        private bool _visibilityCoroutineIsRunning;
        private bool _nextVisibility = true;
        private Coroutine _visibilityCoroutine;

        private void Awake()
        {
            UpdateChildren();
        }

        public void UpdateChildren()
        {
            _sr = GetComponentsInChildren<SpriteRenderer>();
            _graphic = GetComponentsInChildren<Graphic>();
        }

        public void SetVisibility(bool visibility, Action finishCallback = null)
        {
            if (_visibilityCoroutineIsRunning)
            {
                if(_nextVisibility == visibility) return;
                StopCoroutine(_visibilityCoroutine);
            }

            _visibilityCoroutine = StartCoroutine(VisibilityCoroutine(visibility, finishCallback));
        }

        private IEnumerator VisibilityCoroutine(bool visibility, Action finishCallback)
        {
            _visibilityCoroutineIsRunning = true;
            _nextVisibility = visibility;
            
            var from = visibility ? 0f : 1f;
            var to = visibility ? 1f : 0f;

            float deltaTime = FadeSeconds / FadeSteps;
            float deltaStep = 1f / FadeSteps;

            for (int i = 0; i <= FadeSteps; ++i)
            {
                foreach (var sr in _sr)
                {
                    var c = sr.color;
                    c.a = Mathf.Lerp(from, to, deltaStep * i);
                    sr.color = c;
                }
                
                foreach (var graphic in _graphic)
                {
                    var c = graphic.color;
                    c.a = Mathf.Lerp(from, to, deltaStep * i);
                    graphic.color = c;
                }
                
                yield return new WaitForSeconds(deltaTime);
            }
            
            _visibilityCoroutineIsRunning = false;
            
            finishCallback?.Invoke();
        }
    }
}
