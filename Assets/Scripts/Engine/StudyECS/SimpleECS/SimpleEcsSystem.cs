using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Engine.StudyECS.SimpleECS
{
    public class SimpleEcsSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;

            Entities.ForEach((ref Translation translation, ref SimpleEcsComp simpleEcsComp) =>
            {
                translation.Value.y += simpleEcsComp.m_MoveSpeed * deltaTime;
                if (translation.Value.y > 5f)
                {
                    simpleEcsComp.m_MoveSpeed = -math.abs(simpleEcsComp.m_MoveSpeed);
                }
                else if (translation.Value.y < -5f)
                {
                    simpleEcsComp.m_MoveSpeed = math.abs(simpleEcsComp.m_MoveSpeed);
                }
            }).ScheduleParallel();
        }
    }
}
