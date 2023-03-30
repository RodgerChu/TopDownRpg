using GameCore.Fight.Character;
using GameCore.Movement;
using UnityEngine;
using Utils;
using Zenject;

namespace GameCore.Fight.AI
{
    public class MoveToSquadState: BaseState
    {
        [Inject] private SquadPositionsProvider m_destinationProvider;
    
        public override void OnStateEnter(ICharacter character)
        {
        }

        protected override void UpdateInternal(ICharacter character)
        {
            var destination = m_destinationProvider.GetPosition(character);
            var characterPosition = character.characterController.transform.position.XY();
            var targetVector = destination - characterPosition;
            if (Vector2.SqrMagnitude(targetVector) <= 0.1f)
            {
                character.TransitionToState(m_statesPool.Get<IdleState>());
            }
            else
            {
                character.characterController.Move(targetVector.normalized * (character.characterStats.moveSpeed * Time.deltaTime));
            }
        }

        public override void OnStateLeave(ICharacter character)
        {
        }
    }
}
