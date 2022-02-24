using System;
using Engine.UIAnim;
using UnityEngine;

namespace Engine.InspectorExtend
{
    [Serializable]
    public class UIAnimTransformInfo : UIAnimInfoBase
    {
        #region 字段
        
        public Transform m_Transform;

        #endregion
        
        #region 属性
        
        //public override GameObject TargetGo => m_Transform == null ? null : m_Transform.gameObject;

        #endregion
        
        #region 方法
        

        #endregion
    }
}
