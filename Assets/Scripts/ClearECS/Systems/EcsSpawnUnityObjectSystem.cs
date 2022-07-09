using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class EcsSpawnUnityObjectSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<FactoryMonoObject> _factoryMonoObject = default;
        private EcsFilterInject<Inc<EcsNeedCreateViewTag, EcsPosition>> _viewFilter = default;
        
        public void Run(EcsSystems systems)
        {
            foreach (int entity in _viewFilter.Value)
            {
                ref EcsNeedCreateViewTag tag = ref _viewFilter.Pools.Inc1.Get(entity);
                ref EcsPosition ecsPosition = ref _viewFilter.Pools.Inc2.Get(entity);

                GameObject go = _factoryMonoObject.Value.GetObjectByID(tag.objectType);
                go.transform.position = ecsPosition.needPosition;
                LevelViewCreator.SetViewData(tag.objectType, tag.objectData, go);
                ref EcsMonoBeh monoBeh = ref systems.GetWorld().GetPool<EcsMonoBeh>().Add(entity);
                monoBeh.transform = go.transform;

                _viewFilter.Pools.Inc1.Del(entity);
            }
        }
    }
}