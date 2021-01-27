using System;
using UnityEngine.UI;

namespace UnityUtils
{
    public class SceneLoaderOnClick : SceneLoader
    {
        protected virtual void Awake() => GetComponent<Button>().onClick.AddListener(Load);
    }
}