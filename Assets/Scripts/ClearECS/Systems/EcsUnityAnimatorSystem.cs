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
                unityAnimator.playerAnimation.SetState(systems.GetWorld().GetPool<EcsUpdateAnimationTag>().Has(entity) ? 
                    AnimationState.run : AnimationState.idle);

                systems.GetWorld().GetPool<EcsUpdateAnimationTag>().Del(entity);
            }
        }
    }
}