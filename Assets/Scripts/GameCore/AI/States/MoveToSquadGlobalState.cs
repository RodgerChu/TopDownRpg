using System.Collections.Generic;
using GameCore.AI.TransitionConditions;
using GameCore.Animations;
using GameCore.Fight.Character;
using GameCore.Movement;

namespace GameCore.AI.States
{
    public class MoveToSquadGlobalState: BaseCharacterGlobalState
    {
        public ICharacterDestinationProvider destinationPoint { get; private set; }

        public void SetDestination(ICharacterDestinationProvider destination)
        {
            destinationPoint = destination;
        }
    
        public override void OnStateEnter(ICharacter character)
        {
            character.animationController.PlayAnimation(AnimationType.Move);
        }

        protected override void UpdateInternal(ICharacter character)
        {
            var destination = destinationPoint.GetDestination(character);
            var characterPosition = character.position;
            var targetVector = destination - characterPosition;
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
            character.Stop();
        }

        public MoveToSquadGlobalState(List<StateTransitionCondition> transitions) : base(transitions)
        {
        }
    }
}
