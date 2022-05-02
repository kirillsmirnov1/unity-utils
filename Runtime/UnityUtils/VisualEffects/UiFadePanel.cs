using System;
using System.Collections;
using UnityEngine;

namespace UnityUtils.VisualEffects
{
    public class UiFadePanel : MonoBehaviour
    {
        [SerializeField] private float fadeSeconds = .25f;
        [SerializeField] private int fadeSteps = 20;
        [SerializeField] protected CanvasGroup[] groups;

        protected virtual void OnValidate()
        {
            groups = GetComponentsInChildren<CanvasGroup>(true);
        }

        public virtual void Show() 
            => Show(null);
        
        public virtual void Show(Action finishCallback) 
            => StartCoroutine(VisibilityCoroutine(true, finishCallback));

        public virtual void Hide() 
            => Hide(null);

        public virtual void Hide(Action finishCallback) 
            => StartCoroutine(VisibilityCoroutine(false, finishCallback));

        public virtual void ShowAndHide(float showTime = 1f) => ShowAndHide(null, showTime);
        
        public virtual void ShowAndHide(Action finishCallback, float showtime = 1f) 
            => StartCoroutine(ShowAndHideCoroutine(finishCallback, showtime));

        protected virtual IEnumerator ShowAndHideCoroutine(Action finishCallback, float showtime)
        {
            yield return VisibilityCoroutine(true, null);
            yield return new WaitForSeconds(showtime);
            yield return VisibilityCoroutine(false, null);
            finishCallback?.Invoke();
        }
        
        private IEnumerator VisibilityCoroutine(bool visibility, Action finishCallback)
        {
            var from = visibility ? 0f : 1f;
            var to = visibility ? 1f : 0f;

            var deltaTime = fadeSeconds / fadeSteps;
            var deltaStep = 1f / fadeSteps;

            var wfs = new WaitForSeconds(deltaTime);

            for (int iStep = 0; iStep <= fadeSteps; ++iStep)
            {
                for (var iGroup = 0; iGroup < groups.Length; iGroup++)
                {
                    groups[iGroup].alpha = Mathf.Lerp(@from, to, deltaStep * iStep);
                }

                yield return wfs;
            }

            finishCallback?.Invoke();
        }
    }
}