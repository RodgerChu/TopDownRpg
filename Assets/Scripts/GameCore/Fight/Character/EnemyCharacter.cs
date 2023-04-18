using GameCore.Fight.AI;

namespace GameCore.Fight.Character
{
    public class EnemyCharacter: BaseCharacter
    {
        
        
        protected override BaseState GetDefaultState()
        {
            return m_statesPool.Get<IdleState>();
        }
    }
}