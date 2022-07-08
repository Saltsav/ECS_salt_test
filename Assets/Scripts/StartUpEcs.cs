using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;
using Zenject;

namespace ButtonsAndDoors
{
    internal sealed class StartUpEcs : IInitializable, ITickable, IFixedTickable, IDisposable
    {
        private EcsSystems _systems;
        private SceneData _sceneData;


        [Inject]
        private void Construct(SceneData sceneData)
        {
            _sceneData = sceneData;
        }

        public void Initialize()
        {
            _systems = new EcsSystems(new EcsWorld());
            _systems
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
#endif
                //ClearECS
                .Add(new EcsSpawnLevelSystem())
                .Add(new EcsSpawnPlayerSystem())
                .Add(new EcsInputClickSystem())
                .Add(new EcsSetPositionToPlayerSystem())
                .Add(new EcsActiveByDistanceSystem())
                .Add(new EcsColorTriggerSystem())
                .Add(new EcsEnableTriggersSystem())

                .Add(new EcsMoveSystem())
            
                //Unity Dependence
                .Add(new EcsTimeSystem())
                .Add(new EcsUpdateViewOnMapSystem())
                .Inject(_sceneData)
                .Init();
        }

        public void Tick()
        {
            _systems?.Run();
        }

        public void FixedTick()
        {
        }

        public void Dispose()
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