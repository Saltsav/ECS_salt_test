using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsUnityUpdatePositionSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsMoveTag, EcsMonoBeh, EcsPosition>> _updateFilter;
        private EcsFilterInject<Inc<EcsMoveTag>> _needUpdateViewOnMapFilter;

        public void Run(EcsSystems systems)
        {
            foreach (int entity in _updateFilter.Value)
            {
                ref EcsPosition position = ref _updateFilter.Pools.Inc3.Get(entity);
                ref EcsMonoBeh monoBeh = ref _updateFilter.Pools.Inc2.Get(entity);
                monoBeh.transform.position = Utils.ConvertV3ToVector3(position.currentPosition);
                _needUpdateViewOnMapFilter.Pools.Inc1.Del(entity);
            }
        }
    }
}