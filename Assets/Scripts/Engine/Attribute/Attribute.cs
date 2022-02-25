using UnityEngine;

namespace Engine.Attribute
{
    public class LabelAttribute : PropertyAttribute
    {
        public string Label { get; private set; }

        public LabelAttribute(string name)
        {
            Label = name;
        }
    }
}