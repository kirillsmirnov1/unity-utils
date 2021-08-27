using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.Extensions;

namespace UnityUtils.View
{
    public abstract class ListView<T> : MonoBehaviour
    {
        [SerializeField] protected List<ListViewEntry<T>> entries;
        [SerializeField] protected RectTransform scrollContent;
        [SerializeField] protected GameObject listViewEntryPrefab;
        
        protected virtual void OnValidate()
        {
            entries = new List<ListViewEntry<T>>(GetComponentsInChildren<ListViewEntry<T>>(true));
        }
        
        protected virtual void SetEntries(List<T> data)
        {
            CheckConsistency(data);
            FillData(data);
            this.DelayAction(0f, () => LayoutRebuilder.ForceRebuildLayoutImmediate(scrollContent));
        }

        protected virtual void CheckConsistency(List<T> data)
        {
            var viewsToTakenDiff = entries.Count - data.Count;

            if (viewsToTakenDiff < 0)
            {
                SpawnViews(viewsToTakenDiff);
            }
            else if (viewsToTakenDiff > 0)
            {
                DisableViews(viewsToTakenDiff);
            }
        }

        protected virtual void SpawnViews(int viewsToSpawn)
        {
            for (int i = 0; i < viewsToSpawn; i++)
            {
                entries.Add(Instantiate(listViewEntryPrefab, scrollContent).GetComponent<ListViewEntry<T>>());
            }
        }

        protected virtual void DisableViews(int viewsToDisable)
        {
            for (int i = 0; i < viewsToDisable; i++)
            {
                entries[entries.Count - 1 - i].gameObject.SetActive(false);
            }
        }

        protected virtual void FillData(List<T> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                entries[i].Fill(data[i]);
            }
        }
    }
}