﻿using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsColorTriggerSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<ActiveTag, ColorTriggerSend>> _sendFilter = default;
        private EcsFilterInject<Inc<EscColorTriggerReceiver>> _receiveFilter = default;
        private readonly EcsFilterInject<Inc<ActiveTag>> _activeTagFilter = default;
        private bool flag;

        public void Run(EcsSystems systems)
        {
            foreach (int triggerReceiveEntity in _receiveFilter.Value)
            {
                flag = true;
                ref EscColorTriggerReceiver escColorTriggerReceiver = ref _receiveFilter.Pools.Inc1.Get(triggerReceiveEntity);

                foreach (int triggerSendEntity in _sendFilter.Value)
                {
                    ref ColorTriggerSend colorTriggerSend = ref _sendFilter.Pools.Inc2.Get(triggerSendEntity);

                    if (escColorTriggerReceiver.colorID == colorTriggerSend.colorID)
                    {
                        flag = false;
                        if (!_activeTagFilter.Pools.Inc1.Has(triggerReceiveEntity))
                        {
                            _activeTagFilter.Pools.Inc1.Add(triggerReceiveEntity);
                        }

                        break;
                    }
                }

                if (flag)
                {
                    if (_activeTagFilter.Pools.Inc1.Has(triggerReceiveEntity))
                    {
                        _activeTagFilter.Pools.Inc1.Del(triggerReceiveEntity);
                    }
                }
            }
        }
    }
}