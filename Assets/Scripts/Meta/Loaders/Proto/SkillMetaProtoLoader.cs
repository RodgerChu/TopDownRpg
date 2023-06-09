using System;
using System.Reflection;
using GameCore.Fight.SkillsSystem.Abstractions;
using GameCore.Fight.SkillsSystem.Concrete;
using Meta.Data;
using UnityEngine;
using Zenject;

namespace Meta.Loaders.Proto
{
    public class SkillMetaProtoLoader: BaseProtoMetaLoader
    {
        public override void Load(Action<object> callback, DiContainer container)
        {
            SkillMetaDataContainer skillsContainer = new SkillMetaDataContainer();
            var skillsGameplayContainer = new SkillGameplayDataContainer();
            var skillsAssembly = Assembly.GetAssembly(typeof(Skill));
            
            foreach (var skillMetaData in skillsContainer.skills)
            {
                var movementLogicType = skillsAssembly.GetType(skillMetaData.movementType);
                var fireSystemType = skillsAssembly.GetType(skillMetaData.projectileFireLogic);
                var moveSystem = container.Resolve(movementLogicType) as IProjectileMoveSystem;
                var fireSystem = container.Resolve(fireSystemType) as IProjectileFireLogic;
                var projectilePrefab = Resources.Load<GameObject>(skillMetaData.projectilePrefab);
                var hitEffects = new IProjectileHitEffect[skillMetaData.hitEffects.Length];
                var moveEffects = new IProjectileMoveEffect[skillMetaData.movementEffects.Length];
                var ind = 0;
                foreach (var hitEffect in skillMetaData.hitEffects)
                {
                    var hitEffectObj = container.Resolve(skillsAssembly.GetType(hitEffect)) as IProjectileHitEffect;
                    hitEffects[ind++] = hitEffectObj;
                }

                ind = 0;
                foreach (var moveEffect in skillMetaData.movementEffects)
                {
                    var moveEffectObj = container.Resolve(skillsAssembly.GetType(moveEffect)) as IProjectileMoveEffect;
                    moveEffects[ind++] = moveEffectObj;
                }
                
                skillsGameplayContainer.skills.Add(new SkillGameplayData
                {
                    id = skillMetaData.id,
                    hitEffects = hitEffects,
                    moveEffects = moveEffects,
                    moveSystem = moveSystem,
                    projectilePrefab = projectilePrefab,
                    projectileFireLogic = fireSystem,
                    cooldown = skillMetaData.cooldown,
                    range = skillMetaData.range
                });
            }

            callback(skillsGameplayContainer);
        }
    }
}
