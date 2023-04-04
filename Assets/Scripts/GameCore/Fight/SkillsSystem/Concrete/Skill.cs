using System.Collections.Generic;
using GameCore.Fight.SkillsSystem.Abstractions;
using UnityEngine;
using Zenject;

namespace GameCore.Fight.SkillsSystem.Concrete
{
    public class Skill: ITickable, ISkill
    {
        private List<IProjectile> m_launchedProjectiles = new(10);

        private float m_cooldownTime;
        private float m_timeUntilReady;
        
        public bool isReady { get; private set; } = true;
        
        public void Tick()
        {
            foreach (var projectile in m_launchedProjectiles)
            {
                if (projectile.isHit)
                {
                    // on hit
                }
            }

            if (!isReady)
            {
                m_timeUntilReady -= Time.deltaTime;
                isReady = m_timeUntilReady <= 0;
            }
        }
        
        public void Use()
        {
            isReady = false;
            m_timeUntilReady = m_cooldownTime;
        }
    }
}
