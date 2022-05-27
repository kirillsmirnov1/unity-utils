using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityUtils
{
    public class PersistentGameObjectHolder : MonoBehaviour
    {
        private static bool _instanceExists;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if(EditorApplication.isPlaying) return;
            for (var i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
#endif

        private void Awake()
        {
            if (_instanceExists)
            {
                Destroy(gameObject);
            }
            else
            {
                _instanceExists = true;
                DontDestroyOnLoad(gameObject);
                for (var i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
}