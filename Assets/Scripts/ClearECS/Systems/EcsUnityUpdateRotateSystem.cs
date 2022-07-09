using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsUnityUpdateRotateSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsMonoBeh, EcsPosition, EcsPlayerTag>> _filter;

        public void Run(EcsSystems systems)
        {
            foreach (int entity in _filter.Value)
            {
                ref EcsPosition position = ref _filter.Pools.Inc2.Get(entity);
                if (Math.Abs(position.needPosition.x - position.currentPosition.x) > Constatns.FLOAT_ZERO &&
                    Math.Abs(position.needPosition.z - position.currentPosition.z) > Constatns.FLOAT_ZERO)
                {
                    ref EcsMonoBeh monoBeh = ref _filter.Pools.Inc1.Get(entity);
                    monoBeh.transform.LookAt(Utils.ConvertV3ToVector3(position.currentPosition));
                }
            }
        }
    }
}