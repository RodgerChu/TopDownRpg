using System;
using GameCore.Animations;
using GameCore.Fight.Character;
using GameCore.Fight.Character.Stats;

namespace GameCore.Fight.AI.AttackStates
{
    public class MoveToEnemyAttackState: BaseCharacterState
    {
        private Action m_onTargetReached;
        private ICharacter m_target;
        private float m_attackRangeSqr;
        
        public void MoveToAttackRange(ICharacter character, Action onTargetReached)
        {
            m_target = character;
            m_onTargetReached = onTargetReached;
            m_attackRangeSqr = character.characterStats[CharacterStatType.AttackRange] *
                               character.characterStats[CharacterStatType.AttackRange];
        }
        
        public override void OnStateEnter(ICharacter character)
        {
            character.animationController.PlayAnimation(AnimationType.Move);
            character.MoveTo(character.position);
        }

        public override void OnUpdate(ICharacter character)
        {
            var destination = m_target.position;
            var characterPosition = character.position;
            var targetVector = destination - characterPosition;
            if (targetVector.sqrMagnitude < m_attackRangeSqr)
            {
                m_onTargetReached();
                return;
            }
            var charTransform = character.animationController.transform;
            var scale = charTransform.localScale;
            if (scale.x < 0 && targetVector.x > 0 || scale.x > 0 && targetVector.x < 0)
            {
                scale.x = -scale.x;
            }
            charTransform.localScale = scale;
            character.MoveTo(destination);
        }

        public override void OnStateLeave(ICharacter character)
        {
        }
    }
}