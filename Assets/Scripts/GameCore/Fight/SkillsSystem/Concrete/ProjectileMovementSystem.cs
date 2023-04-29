using System.Collections.Generic;
using GameCore.Fight.SkillsSystem.Abstractions;
using UnityEngine;
using Utils;

namespace GameCore.Fight.SkillsSystem.Concrete
{
    public class ProjectileMovementSystem: IProjectileMoveSystem
    {
        private readonly List<IProjectile> m_projectiles = new(100);
        
        public void Tick()
        {
            var dt = Time.deltaTime;
            foreach (var projectile in m_projectiles)
            {
                var projectilePosition = projectile.position;
                var movementVector = (projectile.target.position - projectilePosition.XY()).normalized;
                var newPos = movementVector * (dt * projectile.speed);
                projectile.position += new Vector3(newPos.x, newPos.y);
            }
        }

        public void RegisterProjectile(IProjectile projectile)
        {
            m_projectiles.Add(projectile);
        }

        public void UnregisterProjectile(IProjectile projectile)
        {
            m_projectiles.Remove(projectile);
        }
    }
}
