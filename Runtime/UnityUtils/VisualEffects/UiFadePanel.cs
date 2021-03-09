using System;
using System.Collections;
using UnityEngine;

namespace UnityUtils.VisualEffects
{
    public class UiFadePanel : MonoBehaviour
    {
        protected LazyFade Fade;
        protected virtual void Awake()
        {
            Fade = transform.GetChild(0).GetComponent<LazyFade>();
        }

        public virtual void Show() => Show(null);
        
        public virtual void Show(Action finishCallback)
        {
            Fade.gameObject.SetActive(true);
            Fade.SetVisibility(true, finishCallback);
        }

        public virtual void Hide() => Hide(null);

        public virtual void Hide(Action finishCallback)
        {
            Fade.SetVisibility(false, () =>
            {
                Fade.gameObject.SetActive(false);
                finishCallback?.Invoke();
            });
        }

        public virtual void UpdateFade() => Fade.UpdateChildren();

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