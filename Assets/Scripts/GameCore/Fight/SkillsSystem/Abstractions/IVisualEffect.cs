using GameCore.Fight.Character;

namespace GameCore.Fight.SkillsSystem.Abstractions
{
    public interface IVisualEffect
    {
        void PlayAtTarget(ICharacter target);
    }
}
