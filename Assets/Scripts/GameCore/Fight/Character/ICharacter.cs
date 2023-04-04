using GameCore.Fight.AI;
using GameCore.Fight.Character.Stats;
using UnityEngine;

namespace GameCore.Fight.Character
{
    public enum CharacterType
    {
        Hero,
        Enemy,
    }
    
    public interface ICharacter
    {
        CharacterType characterType { get; }
        CharacterController characterController { get; }
        CharacterStats characterStats { get; }
        void TransitionToState(BaseState state);
    }
}
