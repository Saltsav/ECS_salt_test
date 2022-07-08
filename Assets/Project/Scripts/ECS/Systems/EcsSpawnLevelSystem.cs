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
                systems.GetWorld().GetPool<DistanceTriggerReceiver>().Add(buttonEntity);

                ref EcsPosition ecsPosition = ref systems.GetWorld().GetPool<EcsPosition>().Add(buttonEntity);
                ecsPosition.currentPosition = buttonOnUnity.transform.position;
                ecsPosition.needPosition = buttonOnUnity.transform.position;

                ref ColorTriggerSend colorTriggerSend = ref systems.GetWorld().GetPool<ColorTriggerSend>().Add(buttonEntity);
                colorTriggerSend.colorID = buttonOnUnity.colorID;
            }

            foreach (DoorOnUnity doorOnUnity in levelOnUnity.listDoorOnUnity)
            {
                int doorEntity = systems.GetWorld().NewEntity();

                ref EscColorTriggerReceiver colorTriggerReceiver = ref systems.GetWorld().GetPool<EscColorTriggerReceiver>().Add(doorEntity);
                colorTriggerReceiver.colorID = doorOnUnity.colorID;

                ref EcsPosition position = ref systems.GetWorld().GetPool<EcsPosition>().Add(doorEntity);
                position.currentPosition = doorOnUnity.transform.position;
                position.needPosition = doorOnUnity.transform.position;

                ref EcsMoveSpeed moveSpeed = ref systems.GetWorld().GetPool<EcsMoveSpeed>().Add(doorEntity);
                moveSpeed.moveSpeed = Constatns.OPEN_DOOR_SPEED;

                ref EcsMonoBeh monoBeh = ref systems.GetWorld().GetPool<EcsMonoBeh>().Add(doorEntity);
                monoBeh.transform = doorOnUnity.transform;

                ref EcsMoveIfActiveTag moveIfActive = ref systems.GetWorld().GetPool<EcsMoveIfActiveTag>().Add(doorEntity);
                moveIfActive.startPos = doorOnUnity.transform.position;
                moveIfActive.finalPos = doorOnUnity.transform.position + Vector3.down * Constatns.OPEN_DOOR_DELTA;
            }
        }
    }
}