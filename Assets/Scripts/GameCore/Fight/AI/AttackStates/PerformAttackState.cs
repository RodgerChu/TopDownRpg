using GameCore.Animations;
using GameCore.Fight.Character;
using GameCore.Fight.Character.Stats;

namespace GameCore.Fight.AI.AttackStates
{
    public class PerformAttackState: BaseCharacterState
    {
        private ICharacter m_target;
        private ICharacter m_character;
        
        public void SetTarget(ICharacter target)
        {
            m_target = target;
        }

        private void PlayAttackAnimation()
        {
            m_character.animationController.PlayAnimation(AnimationType.Attack);
        }
        
        public override void OnStateEnter(ICharacter character)
        {
            m_character = character;
            character.animationController.onAnimationCompleted += OnCharacterAnimationFinished;
            PlayAttackAnimation();
        }

        private void OnCharacterAnimationFinished(AnimationType obj)
        {
            PlayAttackAnimation();
            m_target.characterStats[CharacterStatType.Health] -=
                m_character.characterStats[CharacterStatType.AttackPower];
            UnityEngine.Debug.LogError($"Hit character " + m_target + $". Remain health: {m_target.characterStats[CharacterStatType.Health].ToString()}");
        }

        public override void OnUpdate(ICharacter character)
        {
        }

        public override void OnStateLeave(ICharacter character)
        {
            character.animationController.onAnimationCompleted -= OnCharacterAnimationFinished;
        }
    }
}