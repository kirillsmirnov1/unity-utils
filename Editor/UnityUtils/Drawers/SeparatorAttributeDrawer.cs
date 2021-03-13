using UnityEngine;
using UnityUtils.Attributes;

namespace UnityUtils.Drawers
{
    using UnityEditor;
	
    [CustomPropertyDrawer(typeof(SeparatorAttribute))]
    public class SeparatorAttributeDrawer : DecoratorDrawer
    {
        private SeparatorAttribute Separator
        {
            get { return (SeparatorAttribute) attribute; }
        }

        public override void OnGUI(Rect position)
        {
            var title = Separator.Title;
            if (title == "")
            {
                position.height = 1;
                position.y += 19;
                GUI.Box(position, "");
            }
            else
            {
                // TODO handle multi-line Title 
                Vector2 textSize = GUI.skin.label.CalcSize(new GUIContent(title));
                float separatorWidth = (position.width - textSize.x) / 2.0f - 5.0f;
                position.y += 10;

                GUI.Box(new Rect(position.xMin, position.yMin, separatorWidth, 1), "");
                GUI.Label(new Rect(position.xMin + separatorWidth + 5.0f, position.yMin - 8.0f, textSize.x, 20), title);
                GUI.Box(new Rect(position.xMin + separatorWidth + 10.0f + textSize.x, position.yMin, separatorWidth, 1), "");
            }
        }

        public override float GetHeight()
        {
            return Separator.WithOffset ? 36.0f : 26f;
        }
    }
}