using UnityEngine;

namespace UnityUtils.View
{
    public abstract class ListViewEntry<T> : MonoBehaviour
    {
        public virtual void Fill(T data)
        {
            gameObject.SetActive(true);
        }
    }
}