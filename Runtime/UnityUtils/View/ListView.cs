using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.Extensions;

namespace UnityUtils.View
{
    public abstract class ListView<T> : MonoBehaviour
    {
        [SerializeField] private List<ListViewEntry<T>> entries;
        [SerializeField] private RectTransform scrollContent;
        [SerializeField] private GameObject listViewEntryPrefab;
        
        protected virtual void OnValidate()
        {
            entries = new List<ListViewEntry<T>>(GetComponentsInChildren<ListViewEntry<T>>(true));
        }
        
        protected void SetEntries(List<T> data)
        {
            CheckConsistency(data);
            FillData(data);
            this.DelayAction(0f, () => LayoutRebuilder.ForceRebuildLayoutImmediate(scrollContent));
        }

        private void CheckConsistency(List<T> data)
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

        private void SpawnViews(int viewsToSpawn)
        {
            for (int i = 0; i < viewsToSpawn; i++)
            {
                entries.Add(Instantiate(listViewEntryPrefab, scrollContent).GetComponent<ListViewEntry<T>>());
            }
        }

        private void DisableViews(int viewsToDisable)
        {
            for (int i = 0; i < viewsToDisable; i++)
            {
                entries[entries.Count - 1 - i].gameObject.SetActive(false);
            }
        }

        private void FillData(List<T> takenQuests)
        {
            for (int i = 0; i < takenQuests.Count; i++)
            {
                entries[i].Fill(takenQuests[i]);
            }
        }
    }
}