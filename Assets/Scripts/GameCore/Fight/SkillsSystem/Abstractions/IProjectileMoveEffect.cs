using GameCore.Fight.Character;

namespace GameCore.Fight.SkillsSystem.Abstractions
{
    public interface IProjectileMoveEffect
    {
        void OnMoveTick(ICharacter character);
    }
}
