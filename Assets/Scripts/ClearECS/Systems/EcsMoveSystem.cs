using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsMoveSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsPosition, EcsMoveSpeed>> _moveFilter;
        private EcsFilterInject<Inc<EcsTime>> _timeFilter;
        private EcsFilterInject<Inc<EcsMoveTag>> _needUpdateViewOnMapFilter;
        private EcsFilterInject<Inc<EcsUpdateAnimationTag>> _updateAnimationFilter;

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
                float dis = EcsUtils.V3Dis(position.needPosition, position.currentPosition);

                if (dis > Constatns.MIN_DIS_TO_STOP)
                {
                    if (!_needUpdateViewOnMapFilter.Pools.Inc1.Has(entity))
                    {
                        _needUpdateViewOnMapFilter.Pools.Inc1.Add(entity);
                    }

                    if (!_updateAnimationFilter.Pools.Inc1.Has(entity))
                    {
                        _updateAnimationFilter.Pools.Inc1.Add(entity);
                    }

                    ref EcsMoveSpeed moveSpeed = ref _moveFilter.Pools.Inc2.Get(entity);
                    float t = 1 / (dis / moveSpeed.moveSpeed);
                    position.currentPosition = EcsUtils.Lerp(position.currentPosition, position.needPosition, t * deltaTime);
                }
            }
        }
    }
}