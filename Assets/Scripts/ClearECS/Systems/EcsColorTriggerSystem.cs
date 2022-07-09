using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsColorTriggerSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsActiveTag, EcsColorTriggerSend>> _sendFilter;
        private EcsFilterInject<Inc<EscColorTriggerReceiver>> _receiveFilter;
        private EcsFilterInject<Inc<EcsActiveTag>> _activeTagFilter;
        private bool flag;

        public void Run(EcsSystems systems)
        {
            foreach (int triggerReceiveEntity in _receiveFilter.Value)
            {
                flag = true;
                ref EscColorTriggerReceiver escColorTriggerReceiver = ref _receiveFilter.Pools.Inc1.Get(triggerReceiveEntity);

                foreach (int triggerSendEntity in _sendFilter.Value)
                {
                    ref EcsColorTriggerSend ecsColorTriggerSend = ref _sendFilter.Pools.Inc2.Get(triggerSendEntity);

                    if (escColorTriggerReceiver.colorID == ecsColorTriggerSend.colorID)
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