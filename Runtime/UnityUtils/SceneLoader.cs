using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityUtils
{
    public class SceneLoader : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private int sceneIndex;
#pragma warning restore 0649

        public virtual void Load() => SceneManager.LoadScene(sceneIndex);
    }
}