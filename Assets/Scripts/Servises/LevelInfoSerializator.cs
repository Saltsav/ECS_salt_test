using System.Collections.Generic;
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
            sceneData.levelInfo.pointSpawnPlayer = Utils.ConvertVector3ToV3(levelOnUnity.pointSpawnPlayer.position);
            sceneData.levelInfo.objectType = Constatns.ObjectType.level;

            sceneData.levelInfo.listButtonInfo = new List<ButtonInfo>();
            foreach (ButtonOnUnity buttonOnUnity in levelOnUnity.listButtonOnUnity)
            {
                ButtonInfo buttonInfo = new ButtonInfo();
                buttonInfo.objectType = Constatns.ObjectType.button;

                buttonInfo.colorID = buttonOnUnity.colorID;

                buttonInfo.transformInfo = new TransformInfo();
                buttonInfo.transformInfo.position = Utils.ConvertVector3ToV3(buttonOnUnity.transform.position);
                buttonInfo.transformInfo.rotate = Utils.ConvertVector3ToV3(buttonOnUnity.transform.eulerAngles);

                buttonInfo.clr = Utils.ConvertColorToClr(buttonOnUnity.meshRenderer.sharedMaterial.color);

                sceneData.levelInfo.listButtonInfo.Add(buttonInfo);
            }

            sceneData.levelInfo.listDoorInfo = new List<DoorInfo>();
            foreach (DoorOnUnity doorOnUnity in levelOnUnity.listDoorOnUnity)
            {
                DoorInfo doorInfo = new DoorInfo();
                doorInfo.objectType = Constatns.ObjectType.door;

                doorInfo.colorID = doorOnUnity.colorID;

                doorInfo.transformInfo = new TransformInfo();
                doorInfo.transformInfo.position = Utils.ConvertVector3ToV3(doorOnUnity.transform.position);
                doorInfo.transformInfo.rotate = Utils.ConvertVector3ToV3(doorOnUnity.transform.eulerAngles);

                doorInfo.clr = Utils.ConvertColorToClr(doorOnUnity.meshRenderer.sharedMaterial.color);

                sceneData.levelInfo.listDoorInfo.Add(doorInfo);
            }
        }
    }
}