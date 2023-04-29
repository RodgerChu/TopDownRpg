using GameCore.Fight.Character;
using GameCore.Movement;

namespace GameCore.Fight.EnemiesLocator
{
    public interface IEnemiesLocator: ICharacterDestinationProvider
    {
        bool HasEnemiesInSight();
        bool EnemyInSight(ICharacter character);
        ICharacter GetNearestEnemy(ICharacter client);
    }
}
