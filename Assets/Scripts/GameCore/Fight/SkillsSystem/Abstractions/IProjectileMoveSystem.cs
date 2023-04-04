using Zenject;

namespace GameCore.Fight.SkillsSystem.Abstractions
{
    public interface IProjectileMoveSystem: ITickable
    {
        void RegisterProjectile(IProjectile projectile);
        void UnregisterProjectile(IProjectile projectile);
    }
}
