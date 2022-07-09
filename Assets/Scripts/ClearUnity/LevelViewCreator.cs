using System;
using ButtonsAndDoors.ClearUnity;
using Leopotam.EcsLite;
using UnityEngine;

namespace ButtonsAndDoors
{
    public class LevelViewCreator
    {
        public static void SetViewData(Constatns.ObjectType type, object data, GameObject go, EcsSystems systems, int entity)
        {
            switch (type)
            {
                case Constatns.ObjectType.level:
                    break;
                case Constatns.ObjectType.player:
                    PlayerOnUnity playerOnUnity = go.GetComponent<PlayerOnUnity>();
                    ref EcsUnityAnimator unityAnimator = ref systems.GetWorld().GetPool<EcsUnityAnimator>().Add(entity);
                    unityAnimator.playerAnimation = playerOnUnity.playerAnimation;

                    break;
                case Constatns.ObjectType.door:
                    DoorInfo doorInfo = data as DoorInfo;
                    DoorOnUnity doorOnUnity = go.GetComponent<DoorOnUnity>();
                    doorOnUnity.transform.eulerAngles = doorInfo.transformInfo.rotate;
                    doorOnUnity.SetColor(doorInfo.color);
                    break;
                case Constatns.ObjectType.button:
                    ButtonInfo buttonInfo = data as ButtonInfo;
                    ButtonOnUnity buttonOnUnity = go.GetComponent<ButtonOnUnity>();
                    buttonOnUnity.transform.eulerAngles = buttonInfo.transformInfo.rotate;
                    buttonOnUnity.SetColor(buttonInfo.color);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}