using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.View
{
public class FlexibleGridLayout : LayoutGroup 
    {
        [SerializeField] private Vector2 spacing;
        [SerializeField] private Vector2 cellSize;
        [SerializeField] private FitType fitType;
        [SerializeField] private int rows;
        [SerializeField] private int columns;
        [SerializeField] private bool fitX = true;
        [SerializeField] private bool fitY = true;

        public override void CalculateLayoutInputVertical() 
            => UpdateLayout();

        public override void SetLayoutHorizontal() { }

        public override void SetLayoutVertical() { }

        private void UpdateLayout()
        {
            if (fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform)
            {
                var childSqrt = Mathf.Sqrt(transform.childCount);
                rows = Mathf.CeilToInt(childSqrt);
                columns = Mathf.CeilToInt(childSqrt);
            }

            if (fitType == FitType.Width || fitType == FitType.FixedColumns)
            {
                rows = Mathf.CeilToInt(transform.childCount / (float) columns);
            }
            if (fitType == FitType.Height || fitType == FitType.FixedRows)
            {
                columns = Mathf.CeilToInt(transform.childCount / (float) rows);
            }

            var parentWidth = rectTransform.rect.width;
            var parentHeight = rectTransform.rect.height;

            var cellWidth = 
                (parentWidth - spacing.x * (columns - 1) - padding.left - padding.right) / columns;
            
            var cellHeight = 
                (parentHeight - spacing.y * (rows - 1) - padding.top - padding.bottom) / rows;

            cellSize.x = fitX ? cellWidth : cellSize.x;
            cellSize.y = fitY ? cellHeight : cellSize.y;

            var columnCount = 0;
            var rowCount = 0;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                rowCount = i / columns;
                columnCount = i % columns;

                var item = rectChildren[i];

                var xPos = (cellSize.x + spacing.x) * columnCount + padding.left;
                var yPos = (cellSize.y + spacing.y) * rowCount + padding.top;

                SetChildAlongAxis(item, 0, xPos, cellSize.x);
                SetChildAlongAxis(item, 1, yPos, cellSize.y);
            }

            var totalWidth = padding.left + padding.right + cellSize.x * columns + spacing.x * (columns - 1);
            var totalHeight = padding.top + padding.bottom + cellSize.y * rows + spacing.y * (rows - 1);
            
            SetLayoutInputForAxis(totalWidth, totalWidth, -1, 0);
            SetLayoutInputForAxis(totalHeight, totalHeight, -1, 1);
        }

        public enum FitType
        {
            Uniform,
            Width,
            Height,
            FixedRows,
            FixedColumns,
        }
    }
}