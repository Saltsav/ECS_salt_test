using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.UnityEditor;
using Zenject;

namespace ButtonsAndDoors
{
    internal sealed class StartUpEcs : IInitializable, ITickable, IFixedTickable, IDisposable
    {
        private EcsSystems _systems;
        private SceneData _sceneData;
        private FactoryMonoObject _factoryMonoObject;

        [Inject]
        private void Construct(SceneData sceneData, FactoryMonoObject factoryMonoObject)
        {
            _sceneData = sceneData;
            _factoryMonoObject = factoryMonoObject;
        }

        public void Initialize()
        {
            _systems = new EcsSystems(new EcsWorld());
            _systems
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
#endif
                //Services
                .Add(new EcsUnityTimeSystem())
                .Add(new EcsUnityInputClickSystem())

                //ClearECS
                .Add(new EcsSpawnLevelSystem())
                .Add(new EcsSpawnPlayerSystem())
            
                .Add(new EcsSetPositionToPlayerSystem())
                .Add(new EcsActiveByDistanceSystem())
                .Add(new EcsColorTriggerSystem())
                .Add(new EcsEnableTriggersSystem())
                .Add(new EcsMoveSystem())

                //Unity Dependence
                .Add(new EcsUnitySpawnObjectSystem())
                .Add(new EcsUnityUpdateRotateSystem())
                .Add(new EcsUnityUpdatePositionSystem())
                .Add(new EcsUnityAnimatorSystem())
                
                .Inject(_sceneData)
                .Inject(_factoryMonoObject)
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
                _systems.GetWorld().Destroy();
                _systems = null;
            }
        }
    }
}