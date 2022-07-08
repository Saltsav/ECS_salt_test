using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class StartUpEcs : MonoBehaviour
    {
        private EcsSystems _systems;
        [SerializeField] private SceneData _sceneData;

        private void Start()
        {
            _systems = new EcsSystems(new EcsWorld());
            _systems
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
#endif
                .Add(new EcsSpawnLevelSystem())
                .Add(new EcsSpawnUnitSystem())
                .Add(new EcsInputClickSystem())
                .Add(new EcsSetPositionToPlayerSystem())
                .Inject(_sceneData)
                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                // add here cleanup for custom worlds, for example:
                // _systems.GetWorld ("events").Destroy ();
                _systems.GetWorld().Destroy();
                _systems = null;
            }
        }
    }
}