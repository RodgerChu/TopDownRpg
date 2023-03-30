using GameCore.Fight.Character;
using GameCore.Fight.EnemiesLocator;
using GameCore.Movement;
using GameCore.Pooling;
using Zenject;

namespace GameCore.Fight.AI
{
    public abstract class BaseState : ICharacterState
    {
        [Inject] protected IEnemiesLocator m_enemiesLocator;
        [Inject] protected SquadPositionsProvider m_squadPositionsProvider;
        [Inject] protected AttackModeProvider m_attackModeProvider;
        [Inject] protected Pool<BaseState> m_statesPool;

        public abstract void OnStateEnter(ICharacter character);

        public void OnUpdate(ICharacter character)
        {
            if (m_attackModeProvider.attackMode == AttackMode.Aggressive && m_enemiesLocator.HasEnemiesInSight())
            {
                character.TransitionToState(m_statesPool.Get<AttackState>());
            }
            else
            {
                UpdateInternal(character);
            }
        }

        protected abstract void UpdateInternal(ICharacter character);

        public abstract void OnStateLeave(ICharacter character);
    }
}
