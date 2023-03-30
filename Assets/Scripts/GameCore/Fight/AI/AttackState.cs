using GameCore.Fight.Character;
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
            m_characterAttackRangeSqr = character.characterStats.attackRange;
            m_squadPositionsProvider.ReleasePosition(character);
        }

        protected override void UpdateInternal(ICharacter character)
        {
            var destination = m_targetEnemy.characterController.center.XY();
            var targetVector = destination - character.characterController.transform.position.XY();
            if (Vector2.SqrMagnitude(targetVector) <
                m_characterAttackRangeSqr)
            {
                //TODO: attack
                return;
            }

            
            character.characterController.Move(destination.normalized * (character.characterStats.moveSpeed * Time.deltaTime));
        }

        public override void OnStateLeave(ICharacter character)
        {
        }
    }
}
