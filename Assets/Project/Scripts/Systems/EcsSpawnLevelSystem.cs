using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class EcsSpawnLevelSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<SceneData> _sceneData = default;

        public void Init(EcsSystems systems)
        {
            int entity = systems.GetWorld().NewEntity();
            ref EcsLevelTag ecsLevelTag  = ref systems.GetWorld().GetPool<EcsLevelTag>().Add(entity);

            ecsLevelTag.spawnPosition = _sceneData.Value.levelOnUnity.pointSpawnPlayer.position;

            Debug.LogError(_sceneData.Value.playerOnUnity.gameObject.name);
        }
    }
}