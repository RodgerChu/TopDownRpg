using GameCore.Animations;
using GameCore.Fight.Character;
using Utils;

namespace GameCore.Fight.AI
{
    public class IdleState: BaseState
    {
        public override void OnStateEnter(ICharacter character)
        {
            character.animationController.PlayAnimation(AnimationType.Idle);
        }

        protected override void UpdateInternal(ICharacter character)
        {
            if (m_enemiesLocator.HasEnemiesInSight())
            {
                character.TransitionToState(m_statesPool.Get<AttackState>());
            }
            else
            {
                var destination = m_squadPositionsProvider.GetPosition(character);
                var targetVector = destination - character.position;
                if (targetVector.SqrMagnitude() < 0.1f)
                {
                    return;
                }
                
                character.TransitionToState(m_statesPool.Get<MoveToSquadState>());
            }
        }

        public override void OnStateLeave(ICharacter character)
        {
        }
    }
}
