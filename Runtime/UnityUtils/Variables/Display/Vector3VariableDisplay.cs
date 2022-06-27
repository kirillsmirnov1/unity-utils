using TMPro;
using UnityEngine;

namespace UnityUtils.Variables.Display
{
    public class Vector3VariableDisplay : XVariableDisplay<Vector3>
    {
        [SerializeField] private TextMeshProUGUI varName;
        [SerializeField] private TextMeshProUGUI x;
        [SerializeField] private TextMeshProUGUI y;
        [SerializeField] private TextMeshProUGUI z;

        protected void Start()
        {
            varName.text = variable.name;
        }

        protected override void SetText(Vector3 value)
        {
            x.text = value.x.ToString(format);
            y.text = value.y.ToString(format);
            z.text = value.z.ToString(format);
        }
    }
}