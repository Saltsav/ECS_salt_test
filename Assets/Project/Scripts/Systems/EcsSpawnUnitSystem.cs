using Assets.Project.Scripts.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class EcsSpawnUnitSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<SceneData> _sceneData = default;

        public void Init(EcsSystems systems)
        {
            int entity = systems.GetWorld().NewEntity();
            ref EcsPlayerTag ecsPlayerTag = ref systems.GetWorld().GetPool<EcsPlayerTag>().Add(entity);

            ref EcsPositionComponent ecsPositionComponent = ref systems.GetWorld().GetPool<EcsPositionComponent>().Add(entity);
            ecsPositionComponent.currentPosition = _sceneData.Value.levelOnUnity.pointSpawnPlayer.position;
            ecsPositionComponent.needPosition = _sceneData.Value.levelOnUnity.pointSpawnPlayer.position;

        }
    }
}