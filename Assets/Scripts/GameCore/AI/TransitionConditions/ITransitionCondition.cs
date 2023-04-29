using GameCore.AI.States;
using GameCore.Fight.Character;

namespace GameCore.AI.TransitionConditions
{
    public interface ITransitionCondition
    {
        BaseCharacterGlobalState targetState { get; }
        bool Check(ICharacter character);
        void PrepareToTransition(ICharacter character);
    }
}
