using GameCore.Fight.Character;

namespace GameCore.Fight.EnemiesLocator
{
    public interface IEnemiesLocator
    {
        bool HasEnemiesInSight();
        ICharacter GetNearestEnemy(ICharacter client);
    }
}
