using GameCore.Fight.Character;
using GameCore.Fight.SkillsSystem.Abstractions;

namespace GameCore.Fight.SkillsSystem.Concrete.Effects
{
    public class DamageTargetEffect: IProjectileHitEffect
    {
        public void OnHit(ISkill skill, ICharacter caster, ICharacter target)
        {
            target.characterStats.health -= caster.characterStats.abilityPower;
        }
    }
}
