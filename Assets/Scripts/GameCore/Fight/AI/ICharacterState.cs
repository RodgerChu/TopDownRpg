using GameCore.Fight.Character;

namespace GameCore.Fight.AI
{
    public interface ICharacterState
    {
        void OnStateEnter(ICharacter character);
        void OnUpdate(ICharacter character);
        void OnStateLeave(ICharacter character);
    }
}
