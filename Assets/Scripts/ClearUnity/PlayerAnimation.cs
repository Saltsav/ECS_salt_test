using UnityEngine;

namespace ButtonsAndDoors
{
    public enum AnimationState
    {
        none,
        idle,
        run
    }

    public class PlayerAnimation : MonoBehaviour
    {
        private AnimationState currentState = AnimationState.none;
        [SerializeField] private Animator animator;

        public void SetState(AnimationState animationState)
        {
            if (currentState == animationState || animator == null)
            {
                return;
            }
            animator.SetTrigger(animationState.ToString());
            currentState = animationState;
        }
    }
}