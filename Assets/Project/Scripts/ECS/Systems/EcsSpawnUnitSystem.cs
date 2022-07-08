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

            ref EcsPosition ecsPosition = ref systems.GetWorld().GetPool<EcsPosition>().Add(entity);
            ecsPosition.currentPosition = _sceneData.Value.levelOnUnity.pointSpawnPlayer.position;
            ecsPosition.needPosition = _sceneData.Value.levelOnUnity.pointSpawnPlayer.position;

            ref EcsMoveSpeedComponent moveSpeed = ref systems.GetWorld().GetPool<EcsMoveSpeedComponent>().Add(entity);
            moveSpeed.moveSpeed = Constatns.PLAYER_SPEED;

            ref EcsMonoBehComponent monoBeh = ref systems.GetWorld().GetPool<EcsMonoBehComponent>().Add(entity);
            monoBeh.transform = _sceneData.Value.playerOnUnity.transform;

            ref EscTriggerForActiveTag triggerForActiveTag = ref systems.GetWorld().GetPool<EscTriggerForActiveTag>().Add(entity);
            
        }
    }
}