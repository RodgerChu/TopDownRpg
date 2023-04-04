using GameCore.Fight.Character;
using GameCore.Fight.SkillsSystem.Abstractions;
using Zenject;

public class FlashHitEffect: IProjectileHitEffect
{
    [Inject] private IVisualEffect m_flashVisualEffect;
    
    public void OnHit(ISkill skill, ICharacter caster, ICharacter target)
    {
        m_flashVisualEffect.PlayAtTarget(target);
    }
}
