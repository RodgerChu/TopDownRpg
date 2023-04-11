using UnityEngine;

namespace GameCore.Animations
{
    public enum AnimationType
    {
        Idle, Move, Attack, Cast, Die
    }

    public static class AnimationTypeExtensions
    {
        public static int idleAnimationHash = Animator.StringToHash("Idle");
        public static int moveAnimationHash = Animator.StringToHash("Move");
        public static int attackAnimationHash = Animator.StringToHash("Attack");
        public static int castAnimationHash = Animator.StringToHash("Cast");
        public static int dieAnimationHash = Animator.StringToHash("Die");
        
        public static int ToTriggerHash(this AnimationType animation)
        {
            switch (animation)
            {
                case AnimationType.Attack:
                    return attackAnimationHash;
                case AnimationType.Cast:
                    return castAnimationHash;
                case AnimationType.Die:
                    return dieAnimationHash;
                case AnimationType.Idle:
                    return idleAnimationHash;
                case AnimationType.Move:
                    return moveAnimationHash;
                default:
                    return default;
            }
        }
    }
    
    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;

        public void PlayAnimation(AnimationType animation)
        {
            m_animator.SetTrigger(animation.ToTriggerHash());
        }
    }
}
