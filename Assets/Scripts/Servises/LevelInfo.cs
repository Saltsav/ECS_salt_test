using System;
using System.Collections.Generic;

namespace ButtonsAndDoors
{
    [Serializable]
    public class LevelInfo
    {
        public string levelID;
        public Constatns.ObjectType objectType;
        public V3 pointSpawnPlayer;
        public List<ButtonInfo> listButtonInfo;
        public List<DoorInfo> listDoorInfo;
    }

    [Serializable]
    public class DoorInfo
    {
        public Constatns.ObjectType objectType;
        public TransformInfo transformInfo;
        public Constatns.TypeID colorID;
        public Clr clr;
    }

    [Serializable]
    public class ButtonInfo
    {
        public Constatns.ObjectType objectType;
        public TransformInfo transformInfo;
        public Constatns.TypeID colorID;
        public Clr clr;
    }

    [Serializable]
    public class TransformInfo
    {
        public V3 position;
        public V3 rotate;
    }
}