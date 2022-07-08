using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class EcsActiveByDistanceSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<DistanceTriggerReceiver, EcsPosition>> _canActiveFilter = default;
        private EcsFilterInject<Inc<DistanceTriggerSender, EcsPosition>> _triggersFilter = default;
        private readonly EcsFilterInject<Inc<ActiveTag>> _activeTagFilter = default;

        public void Run(EcsSystems systems)
        {
            foreach (int canActiveEntity in _canActiveFilter.Value)
            {
                ref EcsPosition canActivePos = ref _canActiveFilter.Pools.Inc2.Get(canActiveEntity);
                foreach (int triggerEntity in _triggersFilter.Value)
                {
                    ref EcsPosition triggerPos = ref _canActiveFilter.Pools.Inc2.Get(triggerEntity);
                    float dis = Vector3.Distance(canActivePos.currentPosition, triggerPos.currentPosition);
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