using System.Collections.Generic;
using GameCore.Animations;
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

    public interface IMovable
    {
        Vector2 position { get; }
        void MoveTo(Vector2 destination);
    }
    
    public interface ICharacter: IMovable
    {
        CharacterAnimationController animationController { get; }
        Dictionary<CharacterStatType, float> characterStats { get; }
        void TransitionToState(BaseState state);
    }
}
