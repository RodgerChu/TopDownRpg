using System.Collections.Generic;
using GameCore.AI.TransitionConditions;
using GameCore.Animations;
using GameCore.Fight.Character;
using GameCore.Fight.Character.Stats;

namespace GameCore.AI.States
{
    public class AttackGlobalState : BaseCharacterGlobalState
    {
        private ICharacter m_targetEnemy;

        public void SetTarget(ICharacter target)
        {
            if (target is null)
            {
                UnityEngine.Debug.LogError("ayaya");
            }
            
            m_targetEnemy = target;
        }
        
        public override void OnStateEnter(ICharacter character)
        {
            character.animationController.PlayAnimation(AnimationType.Attack);
        }

        protected override void UpdateInternal(ICharacter character)
        {
        }

        public override void OnStateLeave(ICharacter character)
        {
            if (m_targetEnemy is null)
            {
                return;
            }
            
            m_targetEnemy.characterStats[CharacterStatType.Health] -=
                character.characterStats[CharacterStatType.AttackPower];
        }

        public AttackGlobalState(List<StateTransitionCondition> transitions) : base(transitions)
        {
        }
    }
}
