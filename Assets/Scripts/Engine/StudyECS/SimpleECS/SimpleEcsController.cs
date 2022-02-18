using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Engine.StudyECS.SimpleECS
{
    public class SimpleEcsController : MonoBehaviour
    {
        [SerializeField] private Mesh m_Mesh;
        [SerializeField] private Material m_Material;
        [SerializeField] private int m_EntityCount = 1000;

        private void Start()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var entityArchetype = entityManager.CreateArchetype(
                typeof(SimpleEcsComp),
                typeof(Translation),
                typeof(RenderMesh),
                typeof(LocalToWorld),
                typeof(RenderBounds));
            var entityArray = new NativeArray<Entity>(m_EntityCount, Allocator.Temp);
            entityManager.CreateEntity(entityArchetype, entityArray);
            foreach (var entity in entityArray)
            {
                entityManager.SetComponentData(entity, new SimpleEcsComp {m_MoveSpeed = Random.Range(1f, 2f)});
                entityManager.SetComponentData(entity,
                    new Translation() {Value = new float3(Random.Range(-8f, 8f), Random.Range(-5f, 5f), 0)});
                entityManager.SetSharedComponentData(entity,new RenderMesh
                {
                    mesh = this.m_Mesh,
                    material = this.m_Material
                });
            }

            entityArray.Dispose();
        }
    }
}
