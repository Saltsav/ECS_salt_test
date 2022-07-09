using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsSetPositionToPlayerSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsPosition, EcsPlayerTag>> _playerFilter;
        private EcsFilterInject<Inc<EcsInputClick>> _inputClickFilter;

        public void Run(EcsSystems systems)
        {
            foreach (int inputClickEntity in _inputClickFilter.Value)
            {
                ref EcsInputClick inputClick = ref _inputClickFilter.Pools.Inc1.Get(inputClickEntity);
                if (!inputClick.haveClick)
                {
                    return;
                }

                foreach (int playerEntity in _playerFilter.Value)
                {
                    ref EcsPosition position = ref _playerFilter.Pools.Inc1.Get(playerEntity);

                    position.needPosition = inputClick.vector3;
                }
            }
        }
    }
}