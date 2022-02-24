using System;
using UnityEngine;

namespace Engine.InspectorExtend
{
    /// <summary>
    /// 动画播放状态
    /// </summary>
    public enum UIAnimPlayState
    {
        Stop,                   //停止
        Playing,                //播放中
        Pause,                  //暂停
        Finish,                 //完成
    }
    
    /// <summary>
    /// 动画播放控制器
    /// </summary>
    public class UIAnimManager : MonoBehaviour
    {
        public float m_SumTime;                                                     //总时间
        public bool m_IsDefReversed;                                                //默认的是否倒放
        public bool m_IsDefLoop;                                                    //默认的是否循环
        public bool m_IsDefAutoPlay;                                                //默认的是否自动播放

        public UIAnimTransformInfo m_UIAnimTransformInfo;                          //Transform动画信息
        
        [NonSerialized]
        public float m_CurTime;                                                     //当前时间
        [NonSerialized]
        public UIAnimPlayState m_UIAnimPlayState = UIAnimPlayState.Stop;            //当前状态
        
    }
}
