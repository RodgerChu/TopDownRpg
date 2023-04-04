using System.Collections.Generic;
using GameCore.Fight.SkillsSystem.Abstractions;
using UnityEngine;

namespace Meta.Data
{
    public class SkillGameplayData
    {
        public int id;
        public IProjectileMoveSystem moveSystem;
        public GameObject projectilePrefab;
        public IProjectileHitEffect[] hitEffects;
        public IProjectileMoveEffect[] moveEffects;
        public float range;
        public float cooldown;
        public IProjectileFireLogic projectileFireLogic;
    }

    public class SkillGameplayDataContainer
    {
        public List<SkillGameplayData> skills = new List<SkillGameplayData>();
    }
}
