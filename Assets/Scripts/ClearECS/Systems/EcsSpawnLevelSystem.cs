using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsSpawnLevelSystem : IEcsInitSystem
    {
        private EcsCustomInject<SceneData> _sceneData;

        public void Init(EcsSystems systems)
        {
            LevelInfo levelInfo = _sceneData.Value.levelInfo;

            int levelEntity = systems.GetWorld().NewEntity();
            ref EcsLevelTag ecsLevelTag = ref systems.GetWorld().GetPool<EcsLevelTag>().Add(levelEntity);

            ecsLevelTag.spawnPosition = levelInfo.pointSpawnPlayer;

            ref EcsNeedCreateViewTag needCreateViewTag = ref systems.GetWorld().GetPool<EcsNeedCreateViewTag>().Add(levelEntity);
            needCreateViewTag.objectType = Constatns.ObjectType.level;

            ref EcsPosition ecsPositionLevel = ref systems.GetWorld().GetPool<EcsPosition>().Add(levelEntity);
            ecsPositionLevel.currentPosition = new V3(0, 0, 0);
            ecsPositionLevel.needPosition = new V3(0, 0, 0);

            foreach (ButtonInfo buttonInfo in levelInfo.listButtonInfo)
            {
                int buttonEntity = systems.GetWorld().NewEntity();
                systems.GetWorld().GetPool<EcsDistanceTriggerReceiver>().Add(buttonEntity);

                ref EcsPosition ecsPosition = ref systems.GetWorld().GetPool<EcsPosition>().Add(buttonEntity);
                ecsPosition.currentPosition = buttonInfo.transformInfo.position;
                ecsPosition.needPosition = buttonInfo.transformInfo.position;

                ref EcsColorTriggerSend ecsColorTriggerSend = ref systems.GetWorld().GetPool<EcsColorTriggerSend>().Add(buttonEntity);
                ecsColorTriggerSend.colorID = buttonInfo.colorID;

                ref EcsNeedCreateViewTag needCreateViewButtonTag = ref systems.GetWorld().GetPool<EcsNeedCreateViewTag>().Add(buttonEntity);
                needCreateViewButtonTag.objectType = Constatns.ObjectType.button;
                needCreateViewButtonTag.objectData = buttonInfo;
            }

            foreach (DoorInfo doorInfo in levelInfo.listDoorInfo)
            {
                int doorEntity = systems.GetWorld().NewEntity();

                ref EscColorTriggerReceiver colorTriggerReceiver = ref systems.GetWorld().GetPool<EscColorTriggerReceiver>().Add(doorEntity);
                colorTriggerReceiver.colorID = doorInfo.colorID;

                ref EcsPosition position = ref systems.GetWorld().GetPool<EcsPosition>().Add(doorEntity);
                position.currentPosition = doorInfo.transformInfo.position;
                position.needPosition = doorInfo.transformInfo.position;

                ref EcsMoveSpeed moveSpeed = ref systems.GetWorld().GetPool<EcsMoveSpeed>().Add(doorEntity);
                moveSpeed.moveSpeed = Constatns.OPEN_DOOR_SPEED;

                ref EcsMoveIfActiveTag moveIfActive = ref systems.GetWorld().GetPool<EcsMoveIfActiveTag>().Add(doorEntity);
                moveIfActive.startPos = doorInfo.transformInfo.position;
                moveIfActive.finalPos = new V3(doorInfo.transformInfo.position.x, doorInfo.transformInfo.position.y - Constatns.OPEN_DOOR_DELTA, doorInfo.transformInfo.position.z);

                ref EcsNeedCreateViewTag needCreateViewDoorTag = ref systems.GetWorld().GetPool<EcsNeedCreateViewTag>().Add(doorEntity);
                needCreateViewDoorTag.objectType = Constatns.ObjectType.door;
                needCreateViewDoorTag.objectData = doorInfo;
            }
        }
    }
}