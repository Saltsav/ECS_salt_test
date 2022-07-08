using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsEnableTriggersSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<ActiveTag, EcsMoveIfActiveTag, EcsPosition>> _needMoveFilter = default;
        private EcsFilterInject<Inc<EcsMoveIfActiveTag, EcsPosition>, Exc<ActiveTag>> _needStopFilter = default;

        public void Run(EcsSystems systems)
        {
            foreach (int entity in _needMoveFilter.Value)
            {
                ref EcsMoveIfActiveTag moveIfActiveTag = ref _needMoveFilter.Pools.Inc2.Get(entity);
                ref EcsPosition position = ref _needMoveFilter.Pools.Inc3.Get(entity);
                position.needPosition = moveIfActiveTag.finalPos;
            }

            foreach (int entity in _needStopFilter.Value)
            {
                ref EcsPosition position = ref _needStopFilter.Pools.Inc2.Get(entity);
                position.needPosition = position.currentPosition;
            }
        }
    }
}