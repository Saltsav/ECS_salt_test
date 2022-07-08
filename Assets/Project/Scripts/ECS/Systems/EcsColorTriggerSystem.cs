using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ButtonsAndDoors
{
    internal sealed class EcsColorTriggerSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<ActiveComp, ColorTriggerSend>> _sendFilter = default;
        private EcsFilterInject<Inc<ColorTriggerReceive>, Exc<ActiveComp>> _receiveFilter = default;
        private readonly EcsFilterInject<Inc<ActiveComp>> _activeTagFilter = default;

        public void Run(EcsSystems systems)
        {
            foreach (int triggerSendEntity in _sendFilter.Value)
            {
                ref ColorTriggerSend colorTriggerSend = ref _sendFilter.Pools.Inc2.Get(triggerSendEntity);
                foreach (int triggerReceiveEntity in _receiveFilter.Value)
                {
                    ref ColorTriggerReceive colorTriggerReceive = ref _receiveFilter.Pools.Inc1.Get(triggerReceiveEntity);
                    if (colorTriggerReceive.colorID == colorTriggerSend.colorID)
                    {
                        _activeTagFilter.Pools.Inc1.Add(triggerReceiveEntity);
                    }
                }
            }
        }
    }
}
