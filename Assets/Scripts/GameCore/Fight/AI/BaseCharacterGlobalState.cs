using GameCore.Fight.Character;
using GameCore.Fight.EnemiesLocator;
using GameCore.Movement;
using GameCore.Pooling;
using Zenject;

namespace GameCore.Fight.AI
{
    public abstract class BaseCharacterGlobalState : BaseCharacterState
    {
        [Inject] protected IEnemiesLocator m_enemiesLocator;
        [Inject] protected SquadPositionsProvider m_squadPositionsProvider;
        [Inject] protected AttackModeProvider m_attackModeProvider;
        [Inject] protected Pool<BaseCharacterState> m_statesPool;

        public override void OnUpdate(ICharacter character)
        {
            if (this is not AttackGlobalState && m_attackModeProvider.attackMode == AttackMode.Aggressive && m_enemiesLocator.HasEnemiesInSight())
            {
                character.TransitionToState(m_statesPool.Get<AttackGlobalState>());
            }
            else
            {
                UpdateInternal(character);
            }
        }

        protected abstract void UpdateInternal(ICharacter character);
    }
}
