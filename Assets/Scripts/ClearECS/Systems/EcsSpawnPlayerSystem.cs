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
            ecsPosition.currentPosition = _sceneData.Value.levelInfo.pointSpawnPlayer;
            ecsPosition.needPosition = _sceneData.Value.levelInfo.pointSpawnPlayer;

            ref EcsMoveSpeed moveSpeed = ref systems.GetWorld().GetPool<EcsMoveSpeed>().Add(entity);
            moveSpeed.moveSpeed = Constatns.PLAYER_SPEED;

            systems.GetWorld().GetPool<EcsDistanceTriggerSender>().Add(entity);

            ref EcsNeedCreateViewTag needCreateViewTag = ref systems.GetWorld().GetPool<EcsNeedCreateViewTag>().Add(entity);
            needCreateViewTag.objectType = Constatns.ObjectType.player;
        }
    }
}