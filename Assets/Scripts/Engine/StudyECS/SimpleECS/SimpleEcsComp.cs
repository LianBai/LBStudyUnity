using Unity.Entities;
using UnityEngine;

namespace Engine.StudyECS.SimpleECS
{
    /// <summary>
    /// 定义需要的组件
    /// </summary>
    [GenerateAuthoringComponent]
    public struct SimpleEcsComp : IComponentData
    {
        public float m_MoveSpeed;
    }
}