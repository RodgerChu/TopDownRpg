using GameCore.Fight.AI.AttackStates;
using GameCore.Fight.Character;
using GameCore.Fight.Character.Stats;

namespace GameCore.Fight.AI
{
    public class AttackGlobalState : BaseCharacterGlobalState
    {
        private BaseCharacterState m_currentAttackState;
        private ICharacter m_targetEnemy;
        private float m_characterAttackRangeSqr;
        
        public override void OnStateEnter(ICharacter character)
        {
            m_targetEnemy = m_enemiesLocator.GetNearestEnemy(character);
            m_characterAttackRangeSqr = character.characterStats[CharacterStatType.AttackRange] * character.characterStats[CharacterStatType.AttackRange];
            m_squadPositionsProvider.ReleasePosition(character);

            var moveToEnemyAttackState = m_statesPool.Get<MoveToEnemyAttackState>();
            moveToEnemyAttackState.MoveToAttackRange(m_targetEnemy, () =>
            {
                m_currentAttackState.OnStateLeave(character);
                var attackState = m_statesPool.Get<PerformAttackState>();
                attackState.SetTarget(m_targetEnemy);
                attackState.OnStateEnter(character);
                m_currentAttackState = attackState;
            });
            m_currentAttackState = moveToEnemyAttackState;
            m_currentAttackState.OnStateEnter(character);
        }

        protected override void UpdateInternal(ICharacter character)
        {
            m_currentAttackState.OnUpdate(character);
        }

        public override void OnStateLeave(ICharacter character)
        {
            m_currentAttackState.OnStateLeave(character);
            m_statesPool.Return(m_currentAttackState);
        }
    }
}
