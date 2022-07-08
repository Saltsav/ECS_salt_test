﻿using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsSetPositionToPlayerSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsPosition, EcsPlayerTag>> _playerFilter = default;
        private EcsFilterInject<Inc<EcsInputClickComponent>> _inputClickFilter = default;

        public void Run(EcsSystems systems)
        {
            foreach (int inputClickEntity in _inputClickFilter.Value)
            {
                ref EcsInputClickComponent inputClickComponent = ref _inputClickFilter.Pools.Inc1.Get(inputClickEntity);
                if (!inputClickComponent.haveClick)
                {
                    return;
                }

                foreach (int playerEntity in _playerFilter.Value)
                {
                    ref EcsPosition position = ref _playerFilter.Pools.Inc1.Get(playerEntity);

                    position.needPosition = inputClickComponent.vector3;
                }
            }
        }
    }
}