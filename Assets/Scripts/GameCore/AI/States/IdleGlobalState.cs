using System.Collections.Generic;
using GameCore.AI.TransitionConditions;
using GameCore.Animations;
using GameCore.Fight.Character;

namespace GameCore.AI.States
{
    public class IdleGlobalState: BaseCharacterGlobalState
    {
        public override void OnStateEnter(ICharacter character)
        {
            character.animationController.PlayAnimation(AnimationType.Idle);
        }

        protected override void UpdateInternal(ICharacter character)
        {
            if (character.animationController.lastPlayerAnimation != AnimationType.Idle)
            {
                character.animationController.PlayAnimation(AnimationType.Idle);
            }
        }

        public override void OnStateLeave(ICharacter character)
        {
        }

        public IdleGlobalState(List<StateTransitionCondition> transitions) : base(transitions)
        {
        }
    }
}
