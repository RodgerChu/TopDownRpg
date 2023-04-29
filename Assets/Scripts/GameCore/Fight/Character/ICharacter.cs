using System.Collections.Generic;
using GameCore.AI;
using GameCore.AI.States;
using GameCore.Animations;
using GameCore.Fight.Character.Stats;
using UnityEngine;

namespace GameCore.Fight.Character
{
    public interface IMovable
    {
        Vector2 position { get; }
        void MoveTo(Vector2 destination);
        void Stop();
        void TeleportTo(Vector2 position);
    }
    
    public interface ICharacter: IMovable
    {
        CharacterAnimationController animationController { get; }
        Dictionary<CharacterStatType, float> characterStats { get; }
        void TransitionToState(BaseCharacterGlobalState state);
        void SetEnabled(bool enabled);
    }
}
