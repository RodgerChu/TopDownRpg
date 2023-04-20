using GameCore.Fight.AI;

namespace GameCore.Fight.Character
{
    public class EnemyCharacter: BaseCharacter
    {
        
        
        protected override BaseCharacterGlobalState GetDefaultState()
        {
            return m_statesPool.Get<IdleGlobalState>();
        }
    }
}