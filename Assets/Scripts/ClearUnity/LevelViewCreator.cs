using System;
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
                    doorOnUnity.transform.eulerAngles = Utils.ConvertV3ToVector3(doorInfo.transformInfo.rotate);
                    doorOnUnity.SetColor(Utils.ConvertClrToColor(doorInfo.clr));
                    break;
                case Constatns.ObjectType.button:
                    ButtonInfo buttonInfo = data as ButtonInfo;
                    ButtonOnUnity buttonOnUnity = go.GetComponent<ButtonOnUnity>();
                    buttonOnUnity.transform.eulerAngles = Utils.ConvertV3ToVector3(buttonInfo.transformInfo.rotate);
                    buttonOnUnity.SetColor(Utils.ConvertClrToColor(buttonInfo.clr));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}