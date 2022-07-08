using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsSetPositionToPlayerSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsPositionComponent, EcsPlayerTag>> _playerFilter = default;
        private EcsFilterInject<Inc<EcsInputClickComponent>> _inputClickFilter = default;

        public void Run(EcsSystems systems)
        {
            foreach (int playerEntity in _playerFilter.Value)
            {
                foreach (int inputClickEntity in _inputClickFilter.Value)
                {
                    ref EcsPositionComponent positionComponent = ref _playerFilter.Pools.Inc1.Get(playerEntity);
                    ref EcsInputClickComponent inputClickComponent = ref _inputClickFilter.Pools.Inc1.Get(inputClickEntity);
                    positionComponent.needPosition = inputClickComponent.vector3;
                }
            }
        }
    }
}