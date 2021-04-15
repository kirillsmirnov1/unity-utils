using System;
using System.Collections;
using UnityEngine;

namespace UnityUtils.VisualEffects
{
    public class UiFadePanel : MonoBehaviour
    {
        [SerializeField] protected LazyFade[] fades;
        protected virtual void OnValidate()
        {
            fades = GetComponentsInChildren<LazyFade>(true);
        }

        public virtual void Show() => Show(null);
        
        public virtual void Show(Action finishCallback)
        {
            foreach (var fade in fades)
            {
                fade.gameObject.SetActive(true);
                fade.SetVisibility(true, finishCallback);
            }
        }

        public virtual void Hide() => Hide(null);

        public virtual void Hide(Action finishCallback)
        {
            foreach (var fade in fades)
            {
                fade.SetVisibility(false, () =>
                {
                    fade.gameObject.SetActive(false);
                    finishCallback?.Invoke();
                });
            }
        }

        public virtual void UpdateFade()
        {
            foreach (var fade in fades)
            {
                fade.UpdateChildren();
            }
        }

        public virtual void ShowAndHide(float showTime = 1f) => ShowAndHide(null, showTime);
        
        public virtual void ShowAndHide(Action finishCallback, float showtime = 1f) 
            => StartCoroutine(ShowAndHideCoroutine(finishCallback, showtime));

        protected virtual IEnumerator ShowAndHideCoroutine(Action finishCallback, float showtime)
        {
            Show();
            yield return new WaitForSeconds(showtime);
            Hide(finishCallback);
        }
    }
}