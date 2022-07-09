using System.Collections.Generic;
using ButtonsAndDoors.ClearUnity;
using UnityEngine;

namespace ButtonsAndDoors
{
    public class LevelInfoSerializator : MonoBehaviour
    {
        public LevelOnUnity levelOnUnity;
        public SceneData sceneData;

        [ContextMenu("UpdateLevelInfo")]
        public void UpdateLevelInfo()
        {
            if (levelOnUnity == null)
            {
                Debug.LogError("Add levelOnUnity for serialization");
                return;
            }

            sceneData.levelInfo = new LevelInfo();
            sceneData.levelInfo.levelID = levelOnUnity.gameObject.name;
            sceneData.levelInfo.pointSpawnPlayer = levelOnUnity.pointSpawnPlayer.position;
            sceneData.levelInfo.objectType = Constatns.ObjectType.level;

            sceneData.levelInfo.listButtonInfo = new List<ButtonInfo>();
            foreach (ButtonOnUnity buttonOnUnity in levelOnUnity.listButtonOnUnity)
            {
                ButtonInfo buttonInfo = new ButtonInfo();
                buttonInfo.objectType = Constatns.ObjectType.button;

                buttonInfo.colorID = buttonOnUnity.colorID;

                buttonInfo.transformInfo = new TransformInfo();
                buttonInfo.transformInfo.position = buttonOnUnity.transform.position;
                buttonInfo.transformInfo.rotate = buttonOnUnity.transform.eulerAngles;

                buttonInfo.color = buttonOnUnity.meshRenderer.sharedMaterial.color;

                sceneData.levelInfo.listButtonInfo.Add(buttonInfo);
            }

            sceneData.levelInfo.listDoorInfo = new List<DoorInfo>();
            foreach (DoorOnUnity doorOnUnity in levelOnUnity.listDoorOnUnity)
            {
                DoorInfo doorInfo = new DoorInfo();
                doorInfo.objectType = Constatns.ObjectType.door;

                doorInfo.colorID = doorOnUnity.colorID;

                doorInfo.transformInfo = new TransformInfo();
                doorInfo.transformInfo.position = doorOnUnity.transform.position;
                doorInfo.transformInfo.rotate = doorOnUnity.transform.eulerAngles;

                doorInfo.color = doorOnUnity.meshRenderer.sharedMaterial.color;

                sceneData.levelInfo.listDoorInfo.Add(doorInfo);
            }
        }
    }
}