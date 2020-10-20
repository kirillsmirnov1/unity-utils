using System;
using UnityEngine;

namespace UnityUtils.VisualEffects
{
    public class UiFadePanel : MonoBehaviour
    {
        private LazyFade _fade;
        private void Awake()
        {
            _fade = transform.GetChild(0).GetComponent<LazyFade>();
        }

        public void Show(Action finishCallback = null)
        {
            _fade.gameObject.SetActive(true);
            _fade.SetVisibility(true, finishCallback);
        }

        public void Hide(Action finishCallback = null)
        {
            _fade.SetVisibility(false, () =>
            {
                _fade.gameObject.SetActive(false);
                finishCallback?.Invoke();
            });
        }

        public void UpdateFade() => _fade.UpdateChildren();
    }
}