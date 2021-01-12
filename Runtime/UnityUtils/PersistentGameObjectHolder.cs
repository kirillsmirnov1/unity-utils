using UnityEngine;

namespace UnityUtils
{
    public class PersistentGameObjectHolder : MonoBehaviour
    {
        private static bool _instanceExists;

        private void Awake()
        {
            if (_instanceExists)
            {
                Destroy(gameObject);
            }
            else
            {
                _instanceExists = true;
                DontDestroyOnLoad(this);
                for (var i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
}