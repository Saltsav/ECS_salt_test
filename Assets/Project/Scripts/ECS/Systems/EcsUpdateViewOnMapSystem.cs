using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsUpdateViewOnMapSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsNeedUpdateViewOnMapTag, EcsMonoBehComponent, EcsPosition>> _updateFilter = default;
        private readonly EcsFilterInject<Inc<EcsNeedUpdateViewOnMapTag>> _needUpdateViewOnMapFilter = default;

        public void Run(EcsSystems systems)
        {
            foreach (int entity in _updateFilter.Value)
            {
                ref EcsPosition position = ref _updateFilter.Pools.Inc3.Get(entity);
                ref EcsMonoBehComponent monoBehComponent = ref _updateFilter.Pools.Inc2.Get(entity);
                monoBehComponent.transform.position = position.currentPosition;
                _needUpdateViewOnMapFilter.Pools.Inc1.Del(entity);
            }
        }
    }
}