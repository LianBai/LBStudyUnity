using System;
using Engine.InspectorExtend;
using UnityEditor;

namespace Editor.InspectorExtend
{
    [CustomEditor(typeof(UIAnimManager))]
    public class UIAnimManagerEditor : UnityEditor.Editor
    {
        #region 字段

        private UIAnimManager m_UIAnimManager;                                      //面板的脚本
        
        private SerializedProperty m_IsDefReversed;                                 //是否倒放
        private SerializedProperty m_IsDefLoop;                                     //是否循环
        private SerializedProperty m_IsDefAutoPlay;                                 //是否自动播放

        #endregion
        
        #region 继承方法

        private void OnEnable()
        {
            m_UIAnimManager = (UIAnimManager) target;                               //获取绑定的脚本
            
            m_IsDefReversed = serializedObject.FindProperty("m_IsDefReversed");     //获取m_IsDefReversed字段
            m_IsDefLoop = serializedObject.FindProperty("m_IsDefLoop");             //获取m_IsDefLoop字段
            m_IsDefAutoPlay = serializedObject.FindProperty("m_IsDefAutoPlay");     //获取m_IsDefAutoPlay字段
        }

        /// <summary>
        /// 自定义绘制Inspector面板
        /// </summary>
        public override void OnInspectorGUI()
        {
            OnPropertyFieldGUI();
        }

        #endregion
        
        #region 自定义方法

        /// <summary>
        /// 绘制控制播放的按钮
        /// </summary>
        private void OnUIAnimControlBtnGUI()
        {
            
        }

        /// <summary>
        /// 绘制属性字段
        /// </summary>
        private void OnPropertyFieldGUI()
        {
            EditorGUI.BeginChangeCheck();                                       //监听面板是否发生变化
            {
                EditorGUILayout.PropertyField(m_IsDefReversed);                 //绘制m_IsDefReversed属性
                EditorGUILayout.PropertyField(m_IsDefLoop);                     //绘制m_IsDefLoop属性
                EditorGUILayout.PropertyField(m_IsDefAutoPlay);                 //绘制m_IsAutoPlay属性
            }
            if (EditorGUI.EndChangeCheck())                                     //如果发生变化为true
            {
                EditorUtility.SetDirty(target);                                 //标记用于触发保存
                serializedObject.ApplyModifiedProperties();                     //更新序列化的数据
            }
        }

        #endregion
    }
}