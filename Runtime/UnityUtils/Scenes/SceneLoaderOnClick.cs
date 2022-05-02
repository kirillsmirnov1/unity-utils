using UnityEngine.UI;

namespace UnityUtils.Scenes
{
    public class SceneLoaderOnClick : SceneLoader
    {
        protected virtual void Awake() => GetComponent<Button>().onClick.AddListener(Load);
    }
}