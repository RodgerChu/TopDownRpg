using GameCore.Fight.Character;
using UnityEngine;

namespace GameCore.Fight.SkillsSystem.Abstractions
{
    public interface IProjectile
    {
        float speed { get; }
        ICharacter target { get; set; }
        Vector3 position { get; set; }
        bool isHit { get; }
    }

    public interface IChainAttackProjectile: IProjectile
    {
        byte attacksLeft { get; set; }
    }
}
