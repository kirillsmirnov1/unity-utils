using System;
using UnityEngine;

namespace Packages.UnityUtils.UI
{
    public class Clickable : MonoBehaviour
    {
        public static event Action OnClick;
        public virtual void Click() => OnClick?.Invoke();
    }
}