using GameCore.Fight.Character;

namespace GameCore.Fight.SkillsSystem.Abstractions
{
    public interface IProjectileHitEffect
    {
        void OnHit(ISkill skill, ICharacter caster, ICharacter target);
    }
}
