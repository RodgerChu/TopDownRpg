using System.Collections.Generic;
using GameCore.AI.TransitionConditions;
using GameCore.Animations;
using GameCore.Fight.Character;
using GameCore.Fight.Character.Stats;

namespace GameCore.AI.States
{
    public class AttackGlobalState : BaseCharacterGlobalState
    {
        public ICharacter targetEnemy { get; private set; }

        public void SetTarget(ICharacter target)
        {
            if (target is null)
            {
                UnityEngine.Debug.LogError("ayaya");
            }
            
            targetEnemy = target;
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
            if (targetEnemy is null)
            {
                return;
            }
            
            targetEnemy.characterStats[CharacterStatType.Health] -=
                character.characterStats[CharacterStatType.AttackPower];
        }

        public AttackGlobalState(List<StateTransitionCondition> transitions) : base(transitions)
        {
        }
    }
}
