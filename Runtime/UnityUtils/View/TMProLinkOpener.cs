using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityUtils.View
{
    /// <summary>
    /// Opens links clicked on TMPRO<br />
    /// &lt;link="https://www.example.com"&gt;example&lt;/link&gt;<br />
    /// Source: https://www.feelouttheform.net/unity3d-links-textmeshpro/
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public class TMProLinkOpener : MonoBehaviour, IPointerClickHandler {

        public void OnPointerClick(PointerEventData eventData) {
            TMP_Text pTextMeshPro = GetComponent<TMP_Text>();
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(pTextMeshPro, eventData.position, null);  // If you are not in a Canvas using Screen Overlay, put your camera instead of null
            if (linkIndex != -1) { // was a link clicked?
                TMP_LinkInfo linkInfo = pTextMeshPro.textInfo.linkInfo[linkIndex];
                Application.OpenURL(linkInfo.GetLinkID());
            }
        }

    }
}