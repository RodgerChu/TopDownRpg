using GameCore.Animations;
using GameCore.Fight.Character;
using GameCore.Movement;
using UnityEngine;
using Utils;
using Zenject;

namespace GameCore.Fight.AI
{
    public class MoveToSquadGlobalState: BaseCharacterGlobalState
    {
        [Inject] private SquadPositionsProvider m_destinationProvider;
    
        public override void OnStateEnter(ICharacter character)
        {
            character.animationController.PlayAnimation(AnimationType.Move);
        }

        protected override void UpdateInternal(ICharacter character)
        {
            var destination = m_destinationProvider.GetPosition(character);
            var characterPosition = character.position;
            var targetVector = destination - characterPosition;
            if (Vector2.SqrMagnitude(targetVector) <= 0.1f)
            {
                character.TransitionToState(m_statesPool.Get<IdleGlobalState>());
            }
            else
            {
                var charTransform = character.animationController.transform;
                var scale = charTransform.localScale;
                if (scale.x < 0 && targetVector.x > 0 || scale.x > 0 && targetVector.x < 0)
                {
                    scale.x = -scale.x;
                }
                charTransform.localScale = scale;
                character.MoveTo(destination);
            }
        }

        public override void OnStateLeave(ICharacter character)
        {
        }
    }
}
