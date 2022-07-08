using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class EcsTimeSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsTimeComponent>> _timeFilter = default;

        public void Init(EcsSystems systems)
        {
            int entity = systems.GetWorld().NewEntity();
            _timeFilter.Pools.Inc1.Add(entity);
        }
        
        public void Run(EcsSystems systems)
        {
            foreach (int entity in _timeFilter.Value)
            {
                ref EcsTimeComponent timeComponent = ref _timeFilter.Pools.Inc1.Get(entity);
                timeComponent.deltaTime = Time.deltaTime;
            }
        }
    }
}