using Engine.InspectorExtend;
using UnityEditor;
using UnityEngine;

namespace Editor.UIAnim
{
    [CustomPropertyDrawer(typeof(UIAnimTransformInfo))]
    public class UIAnimTransformInfoEditor : PropertyDrawer
    {
        /// <summary>
        /// 获取属性绘制的高度
        /// </summary>
        /// <param name="property"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property);
        }

        /// <summary>
        /// 绘制自定义的面板
        /// </summary>
        /// <param name="position"></param>
        /// <param name="property"></param>
        /// <param name="label"></param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            
        }
    }
}