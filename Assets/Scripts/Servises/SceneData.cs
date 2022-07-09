using UnityEngine;

namespace ButtonsAndDoors
{
    [CreateAssetMenu(menuName = "GameConfiguration/SceneData", fileName = "SceneData")]
    public class SceneData : ScriptableObject
    {
        public LevelInfo levelInfo;
    }
}