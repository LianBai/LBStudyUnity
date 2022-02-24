using System;
using System.Collections.Generic;
using UnityEngine;

namespace Engine.UIAnim
{
    [Serializable]
    public abstract class UIAnimInfoBase
    {
        #region 字段

        private float m_DelayTime;                                              //延迟时间
        private float m_CurTime;                                                //当前时间
        
        [NonSerialized] public float m_SumTime;                                 //总时长

        #endregion

        #region 属性



        #endregion

        #region 方法



        #endregion
    }
}