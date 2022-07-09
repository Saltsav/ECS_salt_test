using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsSpawnPlayerSystem : IEcsInitSystem
    {
        private EcsCustomInject<SceneData> _sceneData;

        public void Init(EcsSystems systems)
        {
            int entity = systems.GetWorld().NewEntity();
            systems.GetWorld().GetPool<EcsPlayerTag>().Add(entity);

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