using GameCore.Fight.AI;
using GameCore.Fight.Character.Stats;
using UnityEngine;

namespace GameCore.Fight.Character
{
    public interface ICharacter
    {
        CharacterController characterController { get; }
        CharacterStats characterStats { get; }
        void TransitionToState(BaseState state);
    }
}
