using System;
using System.Collections;
using TMPro;
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
        private TextMeshProUGUI[] _tmproUi;
        private TextMeshPro[] _tmpro;
        private Image[] _images;
        
        private bool _visibilityCoroutineIsRunning;
        private bool _nextVisibility = true;
        private bool _currentVisibility;
        private Coroutine _visibilityCoroutine;

        private void Awake()
        {
            UpdateChildren();
        }

        public void UpdateChildren()
        {
            _sr = GetComponentsInChildren<SpriteRenderer>();
            _tmproUi = GetComponentsInChildren<TextMeshProUGUI>();
            _tmpro = GetComponentsInChildren<TextMeshPro>();
            _images = GetComponentsInChildren<Image>();
        }

        public void SetVisibility(bool visibility, Action finishCallback = null)
        {
            if (_visibilityCoroutineIsRunning)
            {
                if(_nextVisibility == visibility) return;
                StopCoroutine(_visibilityCoroutine);
            }
            else
            {
                if (visibility == _currentVisibility) return;
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

                foreach (var text in _tmproUi)
                {
                    var c = text.color;
                    c.a = Mathf.Lerp(from, to, deltaStep * i);
                    text.color = c;
                }
                
                foreach (var text in _tmpro)
                {
                    var c = text.color;
                    c.a = Mathf.Lerp(from, to, deltaStep * i);
                    text.color = c;
                }
                
                foreach (var sr in _images)
                {
                    var c = sr.color;
                    c.a = Mathf.Lerp(from, to, deltaStep * i);
                    sr.color = c;
                }
                
                yield return new WaitForSeconds(deltaTime);
            }

            _currentVisibility = visibility;
            _visibilityCoroutineIsRunning = false;
            
            finishCallback?.Invoke();
        }
    }
}
