using ButtonsAndDoors.ClearUnity;
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
            LevelOnUnity levelOnUnity = _sceneData.Value.levelOnUnity;

            int levelEntity = systems.GetWorld().NewEntity();
            ref EcsLevelTag ecsLevelTag  = ref systems.GetWorld().GetPool<EcsLevelTag>().Add(levelEntity);

            ecsLevelTag.spawnPosition = levelOnUnity.pointSpawnPlayer.position;

            foreach (ButtonOnUnity buttonOnUnity in levelOnUnity.listButtonOnUnity)
            {
                int buttonEntity = systems.GetWorld().NewEntity();
                ref EscCanActiveByDistanceTag canActiveByDistanceTag = ref systems.GetWorld().GetPool<EscCanActiveByDistanceTag>().Add(buttonEntity);

                ref EcsPosition ecsPosition = ref systems.GetWorld().GetPool<EcsPosition>().Add(buttonEntity);
                ecsPosition.currentPosition = buttonOnUnity.transform.position;
                ecsPosition.needPosition = buttonOnUnity.transform.position;

                ref ColorTriggerSend colorTriggerSend = ref systems.GetWorld().GetPool<ColorTriggerSend>().Add(buttonEntity);
                colorTriggerSend.colorID = buttonOnUnity.colorID;
            }

            foreach (DoorOnUnity doorOnUnity in levelOnUnity.listDoorOnUnity)
            {
                int buttonEntity = systems.GetWorld().NewEntity();
                ref EscCanActiveByDistanceTag canActiveByDistanceTag = ref systems.GetWorld().GetPool<EscCanActiveByDistanceTag>().Add(buttonEntity);

                ref EcsPosition ecsPosition = ref systems.GetWorld().GetPool<EcsPosition>().Add(buttonEntity);
                ecsPosition.currentPosition = buttonOnUnity.transform.position;
                ecsPosition.needPosition = buttonOnUnity.transform.position;
            }
        }
    }
}