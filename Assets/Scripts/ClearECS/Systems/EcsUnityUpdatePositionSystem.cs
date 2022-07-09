using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsUnityUpdatePositionSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsMoveTag, EcsMonoBeh, EcsPosition>> _updateFilter = default;
        private readonly EcsFilterInject<Inc<EcsMoveTag>> _needUpdateViewOnMapFilter = default;

        public void Run(EcsSystems systems)
        {
            foreach (int entity in _updateFilter.Value)
            {
                ref EcsPosition position = ref _updateFilter.Pools.Inc3.Get(entity);
                ref EcsMonoBeh monoBeh = ref _updateFilter.Pools.Inc2.Get(entity);
                monoBeh.transform.position = position.currentPosition;
                _needUpdateViewOnMapFilter.Pools.Inc1.Del(entity);
            }
        }
    }
}