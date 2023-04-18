using GameCore.Fight.Character;

namespace GameCore.Fight.EnemiesLocator
{
    public interface IEnemiesLocator
    {
        bool HasEnemiesInSight();
        bool EnemyInSight(ICharacter character);
        ICharacter GetNearestEnemy(ICharacter client);
    }
}
