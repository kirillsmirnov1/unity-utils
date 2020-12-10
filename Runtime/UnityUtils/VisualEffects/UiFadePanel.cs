using System;
using System.Collections;
using UnityEngine;

namespace UnityUtils.VisualEffects
{
    public class UiFadePanel : MonoBehaviour
    {
        private LazyFade _fade;
        protected virtual void Awake()
        {
            _fade = transform.GetChild(0).GetComponent<LazyFade>();
        }

        public virtual void Show() => Show(null);
        
        public virtual void Show(Action finishCallback)
        {
            _fade.gameObject.SetActive(true);
            _fade.SetVisibility(true, finishCallback);
        }

        public virtual void Hide() => Hide(null);

        public virtual void Hide(Action finishCallback)
        {
            _fade.SetVisibility(false, () =>
            {
                _fade.gameObject.SetActive(false);
                finishCallback?.Invoke();
            });
        }

        public virtual void UpdateFade() => _fade.UpdateChildren();

        public void ShowAndHide(float showTime = 1f) => ShowAndHide(null, showTime);
        
        public void ShowAndHide(Action finishCallback, float showtime = 1f) 
            => StartCoroutine(ShowAndHideCoroutine(finishCallback, showtime));

        private IEnumerator ShowAndHideCoroutine(Action finishCallback, float showtime)
        {
            Show();
            yield return new WaitForSeconds(showtime);
            Hide(finishCallback);
        }
    }
}