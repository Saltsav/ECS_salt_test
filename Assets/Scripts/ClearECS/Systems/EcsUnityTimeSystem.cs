using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class EcsUnityTimeSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsTime>> _timeFilter;

        public void Init(EcsSystems systems)
        {
            int entity = systems.GetWorld().NewEntity();
            _timeFilter.Pools.Inc1.Add(entity);
        }

        public void Run(EcsSystems systems)
        {
            foreach (int entity in _timeFilter.Value)
            {
                ref EcsTime time = ref _timeFilter.Pools.Inc1.Get(entity);
                time.deltaTime = Time.deltaTime;
            }
        }
    }
}