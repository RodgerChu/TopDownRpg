using GameCore.Fight.Character;

namespace GameCore.Fight.AI
{
    public abstract class BaseCharacterState: ICharacterState
    {
        public abstract void OnStateEnter(ICharacter character);
        public abstract void OnUpdate(ICharacter character);
        public abstract void OnStateLeave(ICharacter character);
    }
}