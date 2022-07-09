using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsActiveByDistanceSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsDistanceTriggerReceiver, EcsPosition>> _canActiveFilter;
        private EcsFilterInject<Inc<EcsDistanceTriggerSender, EcsPosition>> _triggersFilter;
        private EcsFilterInject<Inc<EcsActiveTag>> _activeTagFilter;

        public void Run(EcsSystems systems)
        {
            foreach (int canActiveEntity in _canActiveFilter.Value)
            {
                ref EcsPosition canActivePos = ref _canActiveFilter.Pools.Inc2.Get(canActiveEntity);
                foreach (int triggerEntity in _triggersFilter.Value)
                {
                    ref EcsPosition triggerPos = ref _canActiveFilter.Pools.Inc2.Get(triggerEntity);
                    float dis = EcsUtils.V3Dis(canActivePos.currentPosition, triggerPos.currentPosition);
                    if (dis < Constatns.MIN_DIS_TO_ACTIVE)
                    {
                        if (!_activeTagFilter.Pools.Inc1.Has(canActiveEntity))
                        {
                            _activeTagFilter.Pools.Inc1.Add(canActiveEntity);
                        }
                    }
                    else
                    {
                        if (_activeTagFilter.Pools.Inc1.Has(canActiveEntity))
                        {
                            _activeTagFilter.Pools.Inc1.Del(canActiveEntity);
                        }
                    }
                }
            }
        }
    }
}