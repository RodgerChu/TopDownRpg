using GameCore.Fight.Character;
using GameCore.Fight.SkillsSystem.Abstractions;
using UnityEngine;

namespace GameCore.Fight.SkillsSystem.Concrete.Effects
{
    public class ChainAttackEffect: IProjectileHitEffect
    {
        private RaycastHit2D[] m_nearestEnemy = new RaycastHit2D[1]; 
        
        public void OnHit(ISkill skill, ICharacter caster, ICharacter target)
        {
            /*
            if (skill.projectile is IChainAttackProjectile chainAttackProjectile)
            {
                if (--chainAttackProjectile.attacksLeft == 0)
                {
                    return;
                }
                
                var enemiesInRangeCount = Physics2D.CircleCastNonAlloc(target.characterController.transform.position, skill.attackRange,
                    Vector2.up, m_nearestEnemy, 0.1f, skill.targetType == CharacterType.Hero ? LayersConsts.heroesLayer : LayersConsts.enemiesLayer);
                if (enemiesInRangeCount != 0)
                {
                    skill.projectile.target = m_nearestEnemy[0].transform.GetComponent<ICharacter>();
                }
            }
            */
        }
    }
}
