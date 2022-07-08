using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class EcsSpawnPlayerSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<SceneData> _sceneData = default;

        public void Init(EcsSystems systems)
        {
            int entity = systems.GetWorld().NewEntity();
            ref EcsPlayerTag ecsPlayerTag = ref systems.GetWorld().GetPool<EcsPlayerTag>().Add(entity);

            ref EcsPosition ecsPosition = ref systems.GetWorld().GetPool<EcsPosition>().Add(entity);
            ecsPosition.currentPosition = _sceneData.Value.levelOnUnity.pointSpawnPlayer.position;
            ecsPosition.needPosition = _sceneData.Value.levelOnUnity.pointSpawnPlayer.position;

            ref EcsMoveSpeed moveSpeed = ref systems.GetWorld().GetPool<EcsMoveSpeed>().Add(entity);
            moveSpeed.moveSpeed = Constatns.PLAYER_SPEED;

            ref EcsMonoBeh monoBeh = ref systems.GetWorld().GetPool<EcsMonoBeh>().Add(entity);
            monoBeh.transform = _sceneData.Value.playerOnUnity.transform;

            ref DistanceTriggerSender triggerSender = ref systems.GetWorld().GetPool<DistanceTriggerSender>().Add(entity);
            
        }
    }
}