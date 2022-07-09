using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ButtonsAndDoors
{
    internal sealed class EcsUnityAnimatorSystem : IEcsRunSystem
    {
        private EcsFilterInject<Inc<EcsUnityAnimator>> _animatorFilter = default;

        public void Run(EcsSystems systems)
        {
            foreach (int entity in _animatorFilter.Value)
            {
                ref EcsUnityAnimator unityAnimator = ref _animatorFilter.Pools.Inc1.Get(entity);
                bool flag = systems.GetWorld().GetPool<EcsUpdateAnimationTag>().Has(entity);
                unityAnimator.playerAnimation.SetState(flag ? AnimationState.run : AnimationState.idle);

                systems.GetWorld().GetPool<EcsUpdateAnimationTag>().Del(entity);
            }
        }
    }
}