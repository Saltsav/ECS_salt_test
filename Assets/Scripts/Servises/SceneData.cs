using ButtonsAndDoors.ClearUnity;
using UnityEngine;

namespace ButtonsAndDoors
{
    [CreateAssetMenu(menuName = "GameConfiguration/SceneData", fileName = "SceneData")]
    public class SceneData : ScriptableObject
    {
        [SerializeField] private LevelOnUnity _levelOnUnityPrefab;
        [SerializeField] private PlayerOnUnity _playerOnUnityPrefab;


        private LevelOnUnity currentLevelOnUnity;

        public LevelOnUnity GetLevelOnUnity()
        {
            if (currentLevelOnUnity == null)
            {
                currentLevelOnUnity = Instantiate(_levelOnUnityPrefab, Vector3.zero, Quaternion.identity);
            }

            return currentLevelOnUnity;
        }

        private PlayerOnUnity currentPlayerOnUnity;

        public PlayerOnUnity GetPlayerOnUnity()
        {
            if (currentPlayerOnUnity == null)
            {
                currentPlayerOnUnity = Instantiate(_playerOnUnityPrefab);
            }

            return currentPlayerOnUnity;
        }
    }
}