using System;
using System.Collections.Generic;
using UnityEngine;


namespace ButtonsAndDoors
{
    [Serializable]
    public class LevelInfo
    {
        public string levelID;
        public Constatns.ObjectType objectType;
        public Vector3 pointSpawnPlayer;
        public List<ButtonInfo> listButtonInfo;
        public List<DoorInfo> listDoorInfo;
    }

    [Serializable]
    public class DoorInfo
    {
        public Constatns.ObjectType objectType;
        public TransformInfo transformInfo;
        public Constatns.TypeID colorID;
        public Color color;
    }

    [Serializable]
    public class ButtonInfo
    {
        public Constatns.ObjectType objectType;
        public TransformInfo transformInfo;
        public Constatns.TypeID colorID;
        public Color color;
    }

    [Serializable]
    public class TransformInfo
    {
        public Vector3 position;
        public Vector3 rotate;
    }
}