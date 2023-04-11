using GameCore.Fight.Character;
using GameCore.Fight.Character.Stats;
using UnityEngine;
using Utils;

namespace GameCore.Fight.AI
{
    public class AttackState : BaseState
    {
        private ICharacter m_targetEnemy;
        private float m_characterAttackRangeSqr;
        
        public override void OnStateEnter(ICharacter character)
        {
            m_targetEnemy = m_enemiesLocator.GetNearestEnemy(character);
            m_characterAttackRangeSqr = character.characterStats[CharacterStatType.AttackRange] * character.characterStats[CharacterStatType.AttackRange];
            m_squadPositionsProvider.ReleasePosition(character);
        }

        protected override void UpdateInternal(ICharacter character)
        {
            var destination = m_targetEnemy.position;
            var targetVector = destination - character.position;
            if (Vector2.SqrMagnitude(targetVector) <
                m_characterAttackRangeSqr)
            {
                //TODO: attack
                return;
            }

            
            character.MoveTo(m_targetEnemy.position);
        }

        public override void OnStateLeave(ICharacter character)
        {
        }
    }
}
