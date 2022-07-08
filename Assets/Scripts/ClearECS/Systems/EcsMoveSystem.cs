using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class EcsMoveSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsPosition, EcsMoveSpeed>> _moveFilter = default;
        private EcsFilterInject<Inc<EcsTime>> _timeFilter = default;
        private readonly EcsFilterInject<Inc<EcsNeedUpdateViewOnMapTag>> _needUpdateViewOnMapFilter = default;

        private float deltaTime;

        public void Run(EcsSystems systems)
        {
            foreach (int timeEntity in _timeFilter.Value)
            {
                ref EcsTime time = ref _timeFilter.Pools.Inc1.Get(timeEntity);
                deltaTime = time.deltaTime;
            }

            foreach (int entity in _moveFilter.Value)
            {
                ref EcsPosition position = ref _moveFilter.Pools.Inc1.Get(entity);
                float dis = Vector3.Distance(position.needPosition, position.currentPosition);

                if (dis > Constatns.MIN_DIS_TO_STOP)
                {
                    if (!_needUpdateViewOnMapFilter.Pools.Inc1.Has(entity))
                    {
                        _needUpdateViewOnMapFilter.Pools.Inc1.Add(entity);
                    }

                    ref EcsMoveSpeed moveSpeed = ref _moveFilter.Pools.Inc2.Get(entity);
                    float t = 1 / (dis / moveSpeed.moveSpeed);
                    position.currentPosition = Vector3.Lerp(position.currentPosition, position.needPosition, t * deltaTime);
                }
            
            }
        }
    }
}