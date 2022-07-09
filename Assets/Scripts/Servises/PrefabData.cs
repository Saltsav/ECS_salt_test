using ButtonsAndDoors.ClearUnity;
using UnityEngine;

namespace ButtonsAndDoors
{
    [CreateAssetMenu(menuName = "GameConfiguration/PrefabData", fileName = "PrefabData")]
    public class PrefabData : ScriptableObject
    {
        public GameObject levelPrefab;
        public GameObject doorPrefab;
        public GameObject buttonPrefab;
        public GameObject playerPrefab;
    }
}