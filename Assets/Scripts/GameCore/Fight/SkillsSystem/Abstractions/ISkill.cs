using System;
using GameCore.Fight.Character;

namespace GameCore.Fight.SkillsSystem.Abstractions
{
    public interface ISkill
    {
        bool isReady { get; }
        void Use();
    }
}
