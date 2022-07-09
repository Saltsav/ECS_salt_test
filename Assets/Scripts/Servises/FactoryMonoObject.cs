using System;
using UnityEngine;
using Zenject;

namespace ButtonsAndDoors
{
    public class FactoryMonoObject
    {
        private PrefabData _prefabData;

        [Inject]
        private void Construct(PrefabData prefabData)
        {
            _prefabData = prefabData;
        }

        public GameObject GetObjectByID(Constatns.ObjectType objectType)
        {
            GameObject go = null;
            switch (objectType)
            {
                case Constatns.ObjectType.level:
                    go = GameObject.Instantiate(_prefabData.levelPrefab, Vector3.zero, Quaternion.identity);
                    break;
                case Constatns.ObjectType.player:
                    go = GameObject.Instantiate(_prefabData.playerPrefab, Vector3.zero, Quaternion.identity);
                    break;
                case Constatns.ObjectType.door:
                    go = GameObject.Instantiate(_prefabData.doorPrefab, Vector3.zero, Quaternion.identity);
                    break;
                case Constatns.ObjectType.button:
                    go = GameObject.Instantiate(_prefabData.buttonPrefab, Vector3.zero, Quaternion.identity);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(objectType), objectType, null);
            }

            if (go == null)
            {
                Debug.LogError("ERROR object >> " + objectType + " << not found");
            }

            return go;
        }
    }
}